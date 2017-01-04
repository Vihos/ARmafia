using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nodestroy : MonoBehaviour {

	void Start () {
		DontDestroyOnLoad(transform.gameObject);
	}
}
