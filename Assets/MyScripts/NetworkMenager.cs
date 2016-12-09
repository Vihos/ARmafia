using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkMenager : MonoBehaviour
{

    public GameObject playerPrefab;


    public static void StartServer(string typeName, string gameName)
	{
		Network.InitializeServer (4, 25000, !Network.HavePublicAddress ());
		MasterServer.RegisterHost (typeName, gameName);
	}

	public static void StopServer() {
		Network.Disconnect ();
		MasterServer.UnregisterHost ();
		Debug.LogWarning ("Server stopped.");
	}

	void OnServerInitialized()
	{
        SpawnPlayer();
        Debug.Log("Server Initializied");
	}

    void OnConnectedToServer()
    {
        Debug.Log("Server Joined");
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        Network.Instantiate(playerPrefab, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
    }

    //TODO Remove

    private void JoinServer(HostData hostData)
	{
		Network.Connect(hostData);
	}

}
