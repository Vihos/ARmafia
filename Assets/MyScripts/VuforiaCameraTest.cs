using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VuforiaCameraTest : MonoBehaviour {

    public GameObject cube;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(this.transform.rotation.z);
        //Debug.Log(this.transform.position);
        //z
        cube.transform.position = new Vector3(100,0,190);
        cube.transform.rotation = new Quaternion(45f,45f,45f,1f);
    }
}
