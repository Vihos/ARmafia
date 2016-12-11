using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class serverGUI : MonoBehaviour {

	private const string typeName = "ARMafia";
	private string gameName = "Your Room";
	private string message = "Your message";

    private NetworkPlayer[] netPlayers;
	NetworkMenager nm;
	void Start(){
		nm = GetComponent<NetworkMenager> ();
	}
    void OnGUI(){
		if (!Network.isClient && !Network.isServer) {
			gameName = GUI.TextField (new Rect(2 * Screen.width / 3, 0, Screen.width / 3, Screen.height / 8), gameName, 25);
		
			message = GUI.TextField (new Rect(2 * Screen.width / 3, Screen.height / 8*5, Screen.width / 3, Screen.height / 4), message, 25);

		
        if(Network.isServer)
            {
                netPlayers = Network.connections;
                for (int i = 0; i < netPlayers.Length; i++)
                {
                    Debug.Log(netPlayers[i]);
                }
            }

            if (GUI.Button (new Rect (30, 0, Screen.width/3, Screen.height/8), "Start Server"))
				NetworkMenager.StartServer (typeName, gameName);

			if (GUI.Button (new Rect (2 * Screen.width / 3, Screen.height / 8 * 7, Screen.width / 3, Screen.height / 8), "send")) {
				nm.Sendmessage (message);
				message = "";
			}

			if (GUI.Button (new Rect (0, Screen.height / 8 * 7, Screen.width / 3, Screen.height / 8), "try")) {
				Application.LoadLevel("try");
			}


		} else {
			if (GUI.Button (new Rect (30, 0, Screen.width/3, Screen.height/8), "Stop Server"))
                NetworkMenager.StopServer ();

			message = GUI.TextField (new Rect(2 * Screen.width / 3, Screen.height / 8*5, Screen.width / 3, Screen.height / 4), message, 25);

			if (GUI.Button (new Rect (2 * Screen.width / 3, Screen.height / 8 * 7, Screen.width / 3, Screen.height / 8), "send")) {
				nm.Sendmessage (message);
				message = "";
			}
			if (GUI.Button (new Rect (0, Screen.height / 8 * 7, Screen.width / 3, Screen.height / 8), "try")) {
				Application.LoadLevel("try");
			}
		}
	}
}
