using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkMenager : MonoBehaviour {
	
	private const string typeName = "ARMafia";
	private const string gameName = "testRoom";

	public void StartServer()
	{
		if (!Network.isServer && !Network.isClient) {
			Network.InitializeServer (4, 25000, !Network.HavePublicAddress ());
			MasterServer.RegisterHost (typeName, gameName);
		} else {
			Network.Disconnect ();
			MasterServer.UnregisterHost ();
			Debug.LogWarning ("Server stopped.");
			//Debug.LogWarning ("Server already created.");
		}
	}

	void OnServerInitialized()
	{
		Debug.Log("Server Initializied");
	}

	public void writeLine(string a){
		Debug.Log (a);
	}

}
