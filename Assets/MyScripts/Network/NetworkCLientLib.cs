﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.
using UnityEngine.SceneManagement;

public class NetworkCLientLib : MonoBehaviour 
{

	public HostData[] hostList;
	public NetworkView networkview;
	private ConnectServerGui connectGui;

	private void Start()
	{
	}
	public bool isClient(){
		if (Network.isClient) {
			return true;
		} else {
			return false;
		}
	}
	public void RefreshServerList()
	{
		Debug.Log("Refresh");
		MasterServer.RequestHostList("ARMafia");
	}

	public void OnMasterServerEvent(MasterServerEvent msEvent)
	{
		if (msEvent == MasterServerEvent.HostListReceived)
		{
			Debug.Log ("event hostlistrefreshed");
			hostList = MasterServer.PollHostList();
			if (connectGui!=null) {
				connectGui.GenerateServerButtons(hostList);

			}
		}
	}

	public void JoinServer(string Button)
	{
		int i;
		int.TryParse(Button, out i);
		Network.Connect(hostList[i]);
	}

	void OnConnectedToServer()
	{
		//CreateModalWindow("Клиент", "Вы успешно подключились к серверу");
		//SceneManager.LoadScene("lobby", LoadSceneMode.Single);
	}


	public void FindGui(){
		connectGui  = GameObject.Find("ClientScripts").GetComponent<ConnectServerGui>();
		Debug.Log ("Gui found");
	}
	[RPC]
	public void Change(string texto)
	{
		Application.LoadLevel(texto);
		//Debug.Log("trololololololololo");
	}
}