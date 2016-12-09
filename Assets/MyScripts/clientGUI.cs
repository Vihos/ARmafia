/*
*  ARMafia Project
* 
* Client GUI Render File  
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clientGUI : MonoBehaviour {

    public static HostData[] hostList;

    // Fraphics Render
    void OnGUI()
    {
        // TODO Change positions
        if (GUI.Button(new Rect(30, Screen.height / 8 + 10, Screen.width / 3, Screen.height / 8), "Refresh Hosts"))
            ClientMenager.RefreshHostList();

        serverListGUI();
    }

	void serverListGUI()
    {
        if (hostList != null)
		{
			for (int i = 0; i < hostList.Length; i++)
			{
                // TODO Change positions
                if (GUI.Button (new Rect (30, Screen.height / 4 + 20 + ((Screen.height / 8 + 10) * i), Screen.width / 3, Screen.height / 8), hostList[i].gameName)) { 
					JoinServer(hostList[i]);
				}
			}
		}
	}

    private void JoinServer(HostData hostData)
    {
        Network.Connect(hostData);
    }

    // Debug on server connect Event
    void OnConnectedToServer()
    {
        Debug.Log("Server Joined");
    }

}
