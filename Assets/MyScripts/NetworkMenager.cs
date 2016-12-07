using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkMenager : MonoBehaviour {
	
	private const string typeName = "ARMafia";
	private const string gameName = "testRoom";

	public void StartServer()
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
			if (GUI.Button (new Rect (Screen.width/2-75, 50, 150, 100), "Start Server"))
				StartServer ();
		} else {
			if (GUI.Button (new Rect (Screen.width/2-75, 50, 150, 100), "Stop Server"))
				StopServer ();
		}

		if (GUI.Button(new Rect(Screen.width/2-75, 200, 150, 100), "Refresh Hosts"))
			RefreshHostList();

		if (hostList != null)
		{
			for (int i = 0; i < hostList.Length; i++)
			{
				if (GUI.Button(new Rect(30, 50 + (110 * i), 150, 100), hostList[i].gameName))
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
