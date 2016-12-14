using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Kudan.AR;




	public class ARKudanTracker : MonoBehaviour
	{
		public ARKudanTracker kudanTracker;
		protected Trackable trac;
		public TrackerBase _trackerPlugin;
		public void Start(){
			//_trackerPlugin = kudanTracker._trackerPlugin;
		} 
			public void DebugLog()
			{
				//kudanTracker._lastDetectedTrackables;
		///trac = _trackerPlugin.GetTrackable;
				//Debug.Log(_lastDetectedTrackables[0]);
			}

	}

