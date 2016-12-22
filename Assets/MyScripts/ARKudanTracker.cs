using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Kudan.AR;




	public class ARKudanTracker : MonoBehaviour
	{
		public static ARKudanTracker kudanTracker;
		protected Trackable[] trac;
		public TrackerBase _trackerPlugin;
		public void Start(){
		} 
			public void DebugLog()
			{
		Debug.Log(kudanTracker._trackerPlugin.GetNumTrackables());
			}
		void GetPlugin ()
		{
			#if UNITY_EDITOR_OSX
			_trackerPlugin = new TrackerOSX();
			checkEditorLicenseKey();
			checkLicenseKeyValidity();
			#elif UNITY_EDITOR_WIN
			_trackerPlugin = new TrackerWindows();	
			#elif UNITY_IOS
			_trackerPlugin = new TrackeriOS(_background);
			#elif UNITY_ANDROID
			_trackerPlugin = new TrackerAndroid(_background);
			#endif 
		}
	}

