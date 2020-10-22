//-------------------
// Jason Hughes
// https://reachablegames.com/
// Copyright 2019 Reachable Games, LLC.
//-------------------

using UnityEngine;

//-------------------

namespace ReachableGames
{
	namespace SmoothTrails
	{
		// This class uses a LineRenderer to draw cubic bezier smoothed spline trails.  It is essentially the same 
		// functionality as TrailRender has, only good looking in low frame rate or high velocity situations, with
		// identical point density.
		[RequireComponent(typeof(LineRenderer))]
		public class SmoothTrails : MonoBehaviour
		{
			private LineRenderer lineRenderer;
			private Transform _transform;

			// If you turn this on, it generates a game object per rendered point.  Probably of no value to anyone but the developer.
#if UNITY_EDITOR
			private bool  debugPoints  = false;
#endif

			private Vector3[] bezierSegment = new Vector3[10];  // p0,x,x,p1,x,x,p2,x,x,p3, where p0 is the most recent value, p3 is the oldest
			private bool firstPoint = true;  // special handling for first point, where we replicate it for all bezier knots

			private int numRenderPoints = 0;  // this can be LESS than points.Length, because LineRenderer will allow it, so we just copy the values from the Queue into the points array and only ever resize larger if needed.
			private Vector3[] renderPoints = null;  // these are formatted as SxxSxxSxxSS, where S is a world sample, xx's are bezier points, and the final S is wherever the current position is.
			private float[] renderTimes = null;

			public bool  emitting     = false;
			[Range(0.0f, 20.0f)]
			public int   bezierPoints = 0;
			[Range(0.001f, 10.0f)]
			public float minVertexDistance = 0.1f;
			[Range(1/60.0f, 3.0f)]
			public float decayTime = 1.0f;

			public enum Quality
			{
				Good,
				Better,
				Best
			}
			[Tooltip("Higher quality is a little slower but does more calculations to smooth more points.  Maybe useful for LOD?")]
			public Quality quality = Quality.Best;

			void Awake()
			{
				lineRenderer = GetComponent<LineRenderer>();
				lineRenderer.useWorldSpace = true;
				lineRenderer.loop = false;
				_transform = transform;  // caching this is faster

				ResizePointsArray((bezierPoints+1) * 100);  // rough guess at point count
			}

			public void LateUpdate()
			{
				// First, expire old points by simply reducing the count off the end.  This is fast and cheap, since 
				// LineRenderer doesn't care if the array is longer than the count.
				float timeNow = Time.time;
				while (numRenderPoints>0 && renderTimes[numRenderPoints-1] < timeNow)
					numRenderPoints--;

				// If we are supposed to be adding more points, do so.
				if (emitting)
				{
					Vector3 newPoint = _transform.position;
					if (firstPoint)
					{
						firstPoint = false;
						numRenderPoints = 0;
						bezierSegment[0] = newPoint;
						bezierSegment[3] = newPoint;
						bezierSegment[6] = newPoint;
						bezierSegment[9] = newPoint;

						// resize the arrays if we need to.
						int totalPoints = (bezierPoints+1) * 3 + 1;
						if (totalPoints > renderPoints.Length)
							ResizePointsArray(totalPoints * 2);  // more than we need, so we don't resize immediately

						// initialize the trail, where the one known point is in the last spot and the rest are generated at the head of the array.
						numRenderPoints = totalPoints;
						for (int i=0; i<numRenderPoints; i++)
						{
							renderPoints[i] = newPoint;
							renderTimes[i] = Time.time + decayTime;  // store the death time
						}
					}
					else
					{
						float distRatio = Vector3.Distance(newPoint, bezierSegment[3]) / minVertexDistance;
						if (distRatio > 1.0f)  // if this begins a new segment, copy back all the render points and bezier knots
						{
							// resize the arrays if we need to.
							int totalPoints = (bezierPoints+1) + numRenderPoints;
							if (totalPoints > renderPoints.Length)
								ResizePointsArray(totalPoints * 2);  // more than we need, so we don't resize immediately

							// Copy back the whole array to give us room for the new points, but do it back to front so we don't overwrite ourselves.
							int destIndex = totalPoints-1;
							for (int i=numRenderPoints-1; i>=0; i--, destIndex--)
							{
								renderPoints[destIndex] = renderPoints[i];
								renderTimes[destIndex] = renderTimes[i];
							}
							numRenderPoints = totalPoints;

							bezierSegment[9] = bezierSegment[6];
							bezierSegment[6] = bezierSegment[3];
							bezierSegment[3] = bezierSegment[0];
						}

						// always update the current position in the curve knots and the rendered position
						bezierSegment[0] = newPoint;
						renderPoints[0] = newPoint;
						renderTimes[0] = Time.time + decayTime;  // store the death time

						// Recompute the control points for the curve, generate interpolated times for all the points up to the next knot, 
						// and generate positions for the whole curve, as the whole thing changes as the knots change position
						GenerateSegment(distRatio);
					}
				}
				else  // when emitting is disabled, reset the trail if we start emitting again
				{
					firstPoint = true;
				}

				// Update the whole trail in one go
				lineRenderer.positionCount = numRenderPoints;
				if (numRenderPoints>0)
				{
					lineRenderer.SetPositions(renderPoints);
				}

#if UNITY_EDITOR
				if (debugPoints)
				{
					GameObject parent = new GameObject("Frame"+Time.frameCount);
					Destroy(parent, 0.1f);

					for (int i=0; i<numRenderPoints; i++)
					{
						MakeDebugObject(renderPoints[i], i.ToString()+" at "+renderTimes[i], parent.transform);
					}
				}
#endif
			}

			private void ResizePointsArray(int count)
			{
				Vector3[] newRenderPoints = new Vector3[count];  // allocate larger arrays
				float[] newRenderTimes = new float[count];

				for (int i=0; i<numRenderPoints; i++)  // copy back the data so we don't see flickers/dropouts on resizes
				{
					newRenderPoints[i] = renderPoints[i];
					newRenderTimes[i] = renderTimes[i];
				}
				renderPoints = newRenderPoints;
				renderTimes = newRenderTimes;
			}

			private void GenerateSegment(float distRatio)
			{
				if (bezierPoints>0)
				{
					// fractional part only, thanks
					distRatio -= Mathf.FloorToInt(distRatio);

					// calculate control points between p0 -> p3.
					CalculateControlPointsOpen(ref bezierSegment);

					// compute points on the cubic bezier spline and replace them in the rendered point array
					float step = 1.0f/((float)bezierPoints+1.0f);
					int centerIndex = bezierPoints+1+1;         // points to the first interpolated point in the middle section
					int rightIndex = 2*(bezierPoints+1) + 1;    // points to the first interpolated point in the right section
					float tNow = renderTimes[0];                // grab current time from the current knot
					float tPrev = renderTimes[bezierPoints+1];  // grab previous time from the next knot
					for (int i=1; i<bezierPoints+1; i++, centerIndex++, rightIndex++)
					{
						float stepT = i*step;

						float oneMinusT = 1f - stepT;
						float tSqr = stepT * stepT;
						float oneMinusTSqr = oneMinusT * oneMinusT;
						float oneMinusTCube = oneMinusTSqr * oneMinusT;
						float tCube = tSqr * stepT;

						float t0 = oneMinusTCube;
						float t1 = 3.0f * oneMinusTSqr * stepT;
						float t2 = 3.0f * oneMinusT * tSqr;
						float t3 = tCube;

						// slide from linear points to spline points smoothly on the first segment as the distRatio goes from 0.0 to 1.0, to avoid popping
						Vector3 lerpP = Vector3.Lerp(bezierSegment[0], bezierSegment[3], stepT);
						Vector3 bp0_p1 = t0 * bezierSegment[0] + t1 * bezierSegment[1] + t2 * bezierSegment[2] + t3 * bezierSegment[3];
						renderPoints[i] = Vector3.Lerp(lerpP, bp0_p1, distRatio);
						renderTimes[i] = Mathf.Lerp(tNow, tPrev, stepT);  // rewrite times only for the first set of points, since they change every time a curve is recalculated

						if (quality > Quality.Good)
						{
							renderPoints[centerIndex] = t0 * bezierSegment[3] + t1 * bezierSegment[4] + t2 * bezierSegment[5] + t3 * bezierSegment[6];
							if (quality > Quality.Better)
								renderPoints[rightIndex] = t0 * bezierSegment[6] + t1 * bezierSegment[7] + t2 * bezierSegment[8] + t3 * bezierSegment[9];
						}
					}
				}
			}

			// Super optimized and substituted to produce exactly the control points requred from a 4-knot cubic bezier spline.
			// Originally based on https://www.particleincell.com/2012/bezier-splines/
			private void CalculateControlPointsOpen(ref Vector3[] bezierPoints)
			{
				Vector3 ropt0 = bezierPoints[0] + 2.0f * bezierPoints[3];
				Vector3 ropt1 = (4.0f * bezierPoints[3] + 2.0f * bezierPoints[6]) - 0.5f * ropt0;
				Vector3 ropt2 = (8.0f * bezierPoints[6] + bezierPoints[9]) - 0.57142857142857142857142857142857f * ropt1;

				bezierPoints[7] = ropt2 * 0.1555555555555555555555555555555f;  // direct compute of c0 of last knot
				bezierPoints[4] = (ropt1 - bezierPoints[7]) * 0.28571428571428571428571428571429f;  // calculate c0 based on previous next c0
				bezierPoints[1] = (ropt0 - bezierPoints[4]) * 0.5f;  // calculate c0 based on previous next c0

				// back-substitution, computing c1 from c0's
				bezierPoints[2] = 2.0f * bezierPoints[3] - bezierPoints[4];  // fetching the next point - nextP1
				bezierPoints[5] = 2.0f * bezierPoints[6] - bezierPoints[7];  // fetching the next point - nextP1
				bezierPoints[8] = 0.5f * (bezierPoints[9] + bezierPoints[7]);
			}

#if UNITY_EDITOR
			private void MakeDebugObject(Vector3 pos, string name, Transform p)
			{
				GameObject p1 = new GameObject();
				p1.transform.SetParent(p);
				p1.name = name;
				p1.transform.position = pos;
			}
#endif
		}
	}
}
