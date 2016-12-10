using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkMenager : MonoBehaviour
{

    
	public NetworkView networkview;
	// Use this for initialization
	void Start ()
	{
		 networkview = new NetworkView();
	}

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
        Debug.Log("Server Initializied");
	}

    void OnConnectedToServer()
    {
        Debug.Log("Server Joined");
    }
		

    //TODO Remove

    private void JoinServer(HostData hostData)
	{
		Network.Connect(hostData);

	}
	public void Sendmessage(){
		networkview.RPC("actualizarChatbox",RPCMode.All, "how are you");
	}
	[PunRPC]
	void actualizarChatbox(string texto)
	{
		Debug.Log(texto);

	}
}
