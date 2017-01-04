using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class FindMarker : MonoBehaviour, ITrackableEventHandler {
	private Canvas FindMarkerCanvas;
	private Canvas MainMenuCanvas;
	private Animator FindMarkerAnimator;
	private Animator MainMenuAnimator;
	private TrackableBehaviour myTrackableBehaviour;

    void Start () {
		myTrackableBehaviour = GetComponent<TrackableBehaviour>();
		myTrackableBehaviour.RegisterTrackableEventHandler(this);

		MainMenuCanvas = GameObject.Find("MainMenuCanvas").GetComponent<Canvas>();
		FindMarkerCanvas = GameObject.Find("FindMarkerCanvas").GetComponent<Canvas>();

		MainMenuAnimator = MainMenuCanvas.GetComponent<Animator>();
		FindMarkerAnimator = FindMarkerCanvas.GetComponent<Animator>();
	}

	public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
		if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			Debug.Log("true");
			MainMenuAnimator.SetBool("showMenuStatus", true);
			FindMarkerAnimator.SetBool("markerHelperStatus", true);
		}
		else if (newStatus == TrackableBehaviour.Status.NOT_FOUND)
		{
			Debug.Log("false");
			MainMenuAnimator.SetBool("showMenuStatus", false);
			FindMarkerAnimator.SetBool("markerHelperStatus", false);
		}
		else
		{
			
		}
	}

	public void DebugIt(String message)
	{
		Debug.Log(message);
	}

	void Update () {
		//Debug.Log(myTrackableBehaviour.CurrentStatus);
	}
}
