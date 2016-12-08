using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clientGUI : MonoBehaviour {

	ClientMenager clientMenager;
	public HostData[] hostList;

	void Start() {
		clientMenager = new ClientMenager ();
	}

	void OnGUI(){
		if (GUI.Button(new Rect(30, Screen.height/8+10, Screen.width/3, Screen.height/8), "Refresh Hosts"))
			clientMenager.RefreshHostList();

		//clientMenager.OnMasterServerEvent ();
	}

	void serverListGUI(){
		HostData[] hostlist = clientMenager.hostList;

		if (hostlist != null)
		{
			for (int i = 0; i < hostlist.Length; i++)
			{
				if (GUI.Button (new Rect (30, Screen.height / 4 + 20 + ((Screen.height / 8 + 10) * i), Screen.width / 3, Screen.height / 8), hostlist [i].gameName)) {
					//clientMenager.JoinServer(clientMenager.hostList[i], clientMenager.hostList);
				}
			}
		}
	}
}
