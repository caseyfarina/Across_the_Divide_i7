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
		public class FrameRateKiller : MonoBehaviour
		{
			public float fps = 60.0f;
			void Update()
			{
				float waitUntil = Time.realtimeSinceStartup + 1.0f/fps;
				while (Time.realtimeSinceStartup < waitUntil);
			}
		}
	}
}