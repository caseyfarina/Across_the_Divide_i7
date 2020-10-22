//-------------------
// Jason Hughes
// https://reachablegames.com/
// Copyright 2019 Reachable Games, LLC.
//-------------------

using UnityEngine;

namespace ReachableGames
{
	namespace SmoothTrails
	{
		public class RotateChaotically : MonoBehaviour
		{
			public Vector3 eulers;
			public Vector3 chance;

			void Update()
			{
				transform.Rotate(Random.value < chance.x ? eulers.x * Time.deltaTime:0.0f, 
								Random.value < chance.y ? eulers.y * Time.deltaTime:0.0f, 
								Random.value < chance.z ? eulers.z * Time.deltaTime:0.0f);
			}
		}
	}
}