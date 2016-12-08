using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkMenager : MonoBehaviour {
	
	private const string typeName = "ARMafia";
	private string gameName = "Your Room";

	public void StartServer(string gameName)
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

	void OnGUI(){
		if (!Network.isClient && !Network.isServer) {
			gameName = GUI.TextField (new Rect(2*Screen.width/3,0,Screen.width/3,Screen.height/8), gameName, 25);

			if (GUI.Button (new Rect (30, 0, Screen.width/3, Screen.height/8), "Start Server"))
				StartServer (gameName);
		} else {
			if (GUI.Button (new Rect (30, 0, Screen.width/3, Screen.height/8), "Stop Server"))
				StopServer ();
		}

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

	public void writeLine(string a){
		Debug.Log (a);
	}

	//!!!

	private HostData[] hostList;

	private void RefreshHostList()
	{
		MasterServer.RequestHostList(typeName);
	}

	void OnMasterServerEvent(MasterServerEvent msEvent)
	{
		if (msEvent == MasterServerEvent.HostListReceived)
			hostList = MasterServer.PollHostList();
	}

	private void JoinServer(HostData hostData)
	{
		Network.Connect(hostData);
	}

	void OnConnectedToServer()
	{
		Debug.Log("Server Joined");
	}

}
