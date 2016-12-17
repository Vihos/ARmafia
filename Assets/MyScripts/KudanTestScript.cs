using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Kudan.AR
{
    public class KudanTestScript : MonoBehaviour
    {
        public KudanTracker _KudanTracker;

        public void TestMethod()
        {
            Vector3 position;
            Quaternion orientation;

            _KudanTracker.ArbiTrackGetPose(out position, out orientation);
            Debug.Log(position + " " + orientation);

            _KudanTracker.FloorPlaceGetPose(out position, out orientation);
            Debug.Log(position + " " + orientation);
        }
    }
}