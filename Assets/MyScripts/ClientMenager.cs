/*
*  ARMafia Project
* 
* Client Logic File  
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientMenager : MonoBehaviour {

    // Network servers filter (GameName) 
	private const string typeName = "ARMafia";


    // OnCall create event ant wait for servers tracking (by filter 'typeName')
    public static void RefreshHostList()
	{
        MasterServer.RequestHostList(typeName);
    }

    // Event which was fill array with servers (It will wait far answer from MasterServer method)
    public void OnMasterServerEvent(MasterServerEvent msEvent)
	{
		if (msEvent == MasterServerEvent.HostListReceived) {
            clientGUI.hostList = MasterServer.PollHostList();
        }
	}

    //
    // !!!In Progress!!!
    // Connect to server method
    public static void JoinServer(HostData hostData)
    {
        Network.Connect(hostData);
    }

    // Debug on server connect Event
    void OnConnectedToServer()
    {
        Debug.Log("Server Joined");
    }

    private void OnFailedToConnect(NetworkConnectionError error)
    {
        Debug.Log(error);
    }

	[PunRPC]
	void actualizarChatbox(string texto)
	{
		Debug.Log(texto);
	}

}
