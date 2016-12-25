using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.
using UnityEngine.SceneManagement;

public class DayNight : MonoBehaviour {
	public Text time;
	public Image moonSoon;
	private bool isDay = true;
	private int count=180;
	private int max= 180;
	// Use this for initialization
	void Start () {
		
		//moonSoon.transform.rotation= new Quaternion(0f,0f,180f,0f);
		Invoke("UpdateTimer", 1);
	}
	void UpdateTimer( ){

		if (count > 0) {
			if (isDay) {
				time.text = (count / max).ToString () + ":" + (count % max).ToString ();
				moonSoon.transform.rotation= Quaternion.Euler(new Vector3(0, 0, 180*count/max));
				Invoke ("UpdateTimer", 1);
				count--;
			} else {
				time.text = (count / max).ToString () + ":" + (count % max).ToString ();
				moonSoon.transform.rotation= Quaternion.Euler(new Vector3(0, 0, 180+180*count/max));
				Invoke ("UpdateTimer", 1);
				count--;
			}
		} else {
			isDay = !(isDay);
			count = max;
			Invoke ("UpdateTimer", 0);
		}
	} 
	// Update is called once per frame
	void Update () {
		
	}
}
