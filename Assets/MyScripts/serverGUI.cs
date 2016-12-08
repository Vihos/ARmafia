using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class serverGUI : MonoBehaviour {

	private const string typeName = "ARMafia";
	private string gameName = "Your Room";

	NetworkMenager networkMenager;

	void Start() {
		networkMenager = new NetworkMenager ();
	}

	void OnGUI(){
		if (!Network.isClient && !Network.isServer) {
			gameName = GUI.TextField (new Rect(2*Screen.width/3,0,Screen.width/3,Screen.height/8), gameName, 25);

			if (GUI.Button (new Rect (30, 0, Screen.width/3, Screen.height/8), "Start Server"))
				networkMenager.StartServer (typeName, gameName);
		} else {
			if (GUI.Button (new Rect (30, 0, Screen.width/3, Screen.height/8), "Stop Server"))
				networkMenager.StopServer ();
		}
	}
}
