using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkMenager : ScriptableObject {

	public void StartServer(string typeName, string gameName)
	{
		Network.InitializeServer (4, 25000, !Network.HavePublicAddress ());
		MasterServer.RegisterHost (typeName, gameName);
	}

	public void StopServer() {
		Network.Disconnect ();
		MasterServer.UnregisterHost ();
		Debug.LogWarning ("Server stopped.");
	}

	void OnServerInitialized()
	{
		Debug.Log("Server Initializied");
	}

	// End Menager
	/*
	void OnGUI(){
		if (GUI.Button(new Rect(30, Screen.height/8+10, Screen.width/3, Screen.height/8), "Refresh Hosts"))
			RefreshHostList();

		if (hostList != null)
		{
			for (int i = 0; i < hostList.Length; i++)
			{
				if (GUI.Button(new Rect(30,  Screen.height/4+20 + ((Screen.height/8+10) * i), Screen.width/3, Screen.height/8), hostList[i].gameName))
					JoinServer(hostList[i]);
			}
		}
	}
	*/

	public void writeLine(string a){
		Debug.Log (a);
	}


	//TODO Remove

	private void JoinServer(HostData hostData)
	{
		Network.Connect(hostData);
	}

	void OnConnectedToServer()
	{
		Debug.Log("Server Joined");
	}

}
