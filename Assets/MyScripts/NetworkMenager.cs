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
