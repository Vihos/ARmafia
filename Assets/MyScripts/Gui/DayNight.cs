using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.
using UnityEngine.SceneManagement;

public class DayNight : MonoBehaviour {
	public Text time;
	public Image moonSoon;
	private bool isDay = true;
<<<<<<< HEAD
	private int count=180;
	private int max= 180;
=======
	private int timer=10;
	private int max=20;
	private NetworkCLientLib networklib;
>>>>>>> refs/remotes/origin/dev.lasthope
	// Use this for initialization
	void Start () {
		networklib  = GameObject.Find("NetworkV").GetComponent<NetworkCLientLib>();
		networklib.FindDayNight();
		Invoke("UpdateTimer", 1);
	}
	void UpdateTimer( ){

		if (timer > 0) {
			if (isDay) {
				time.text = (timer / 60).ToString () + ":" + (timer % 60).ToString ();
				moonSoon.transform.rotation= Quaternion.Euler(new Vector3(0, 0, 180+180*timer/max));
				Invoke ("UpdateTimer", 1);
				timer--;
			} else {
				time.text = (timer / 60).ToString () + ":" + (timer % 60).ToString ();
				moonSoon.transform.rotation= Quaternion.Euler(new Vector3(0, 0, 180*timer/max));
				Invoke ("UpdateTimer", 1);
				timer--;
			}
		} else {
			isDay = !(isDay);
			timer = max;
			Invoke ("UpdateTimer", 0);
		}
	} 
	public void SetDay(){
		isDay = true;
		timer = max;
	}
	public void SetNight(){
		isDay = false;
		timer = max;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
