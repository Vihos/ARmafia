using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class ConnectToServer : MonoBehaviour {

    public Canvas ListScroll;
    public static HostData[] hostList;

    private void Start()
    {
        RefreshServerList();
        Debug.Log("Started");
    }

    public void RefreshServerList()
    {
        Debug.Log("Refresh");
        MasterServer.RequestHostList("ARMafia");

        if (hostList != null)
        {
            for (int i = 0; i < hostList.Length; i++)
            {
                Debug.Log(hostList[i]);
                // TODO Change positions
                if (GUI.Button(new Rect(30, Screen.height / 4 + 20 + ((Screen.height / 8 + 10) * i), Screen.width / 3, Screen.height / 8), hostList[i].gameName))
                {
                    ClientMenager.JoinServer(hostList[i]);
                }
            }
        }
    }

}
