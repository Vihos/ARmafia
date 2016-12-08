using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientMenager : MonoBehaviour {

	private const string typeName = "ARMafia";

	public void RefreshHostList()
	{
		MasterServer.RequestHostList(typeName);
	}

	public void OnMasterServerEvent(MasterServerEvent msEvent)
	{
		Debug.Log ("Listener");

		if (msEvent == MasterServerEvent.HostListReceived) {
			hostList = MasterServer.PollHostList ();
		}
	}

	/*
	void OnGUI(){
		if (hostList != null) {
			for (int i = 0; i < hostList.Length; i++) {
				if (GUI.Button (new Rect (30, Screen.height / 4 + 20 + ((Screen.height / 8 + 10) * i), Screen.width / 3, Screen.height / 8), hostList [i].gameName)) {
					//clientMenager.JoinServer(clientMenager.hostList[i], clientMenager.hostList);
				}
			}
		}
	}*/

}
