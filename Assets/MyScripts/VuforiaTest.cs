using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VuforiaTest : MonoBehaviour, Vuforia.ITrackableEventHandler
{
    private TrackableBehaviour myTrackableBehaviour;

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        throw new NotImplementedException();
    }

    private void OnTrackingFound()
    {
        Debug.Log("a");
    }

    void Start () {
        myTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (myTrackableBehaviour)
        {
            myTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }
	
	void Update () {
        //Debug.Log(myTrackableBehaviour.transform.position);
    }
}
