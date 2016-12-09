using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class serverGUI : MonoBehaviour {

	private const string typeName = "ARMafia";
	private string gameName = "Your Room";

	void OnGUI(){
		if (!Network.isClient && !Network.isServer) {
			gameName = GUI.TextField (new Rect(2*Screen.width/3,0,Screen.width/3,Screen.height/8), gameName, 25);

			if (GUI.Button (new Rect (30, 0, Screen.width/3, Screen.height/8), "Start Server"))
				NetworkMenager.StartServer (typeName, gameName);
		} else {
			if (GUI.Button (new Rect (30, 0, Screen.width/3, Screen.height/8), "Stop Server"))
                NetworkMenager.StopServer ();
		}
	}
}
