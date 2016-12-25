using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.
using UnityEngine.SceneManagement;
public class NetworkCLientLib : MonoBehaviour 
{

	public HostData[] hostList;
	public NetworkView networkview;
	private ConnectServerGui connectGui;
	private int myId;
	private bool dayObjectFount = false;
	private DayNight dayNight;
	private gameMethods gamem;

	private void Start()
	{
		myId = (int)Random.Range (0, 1000000);
	}
	public bool isClient(){
		if (Network.isClient) {
			return true;
		} else {
			return false;
		}
	}



	public void FindDayNight(){
		dayNight  = GameObject.Find("DayNight").GetComponent<DayNight>();
		dayObjectFount = true;
	}
	public void FindGameMethos(){
		gamem  = GameObject.Find("ARCamera").GetComponent<gameMethods>();
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
                Debug.Log("connectGui != null");
				connectGui.GenerateServerButtons(hostList);
                connectGui.remooveModalRefresh();

            }
		}
	}

	public void JoinServer(string Button)
	{
        connectGui.createModalRefresh();
        int i;
		int.TryParse(Button, out i);
		Network.Connect(hostList[i]);

	}

	void OnConnectedToServer()
	{
        networkview.RPC ("AddClient", RPCMode.Others, myId,"Armafia");
	}


	public void FindGui(){
		connectGui  = GameObject.Find("ClientScripts").GetComponent<ConnectServerGui>();
		Debug.Log ("Gui found");
	}

	public void sendToServer(Vector3 v31,Vector3 v32){
		networkview.RPC ("AceptCoords", RPCMode.Others, myId, v31,v32);
	}

	[RPC]
	public void Change(string texto)
	{
		Application.LoadLevel(texto);
	}
	[RPC]
	public void SetDay()
	{
		Debug.Log ("Setting day");
		if(dayObjectFount){
			dayNight.SetDay();
		}
	}
	[RPC]
	public void SetNight()
	{
		Debug.Log ("Setting Night");
		if(dayObjectFount){
			dayNight.SetNight();
		}
	}

	[RPC]
	public void SendCoordsUsers(int id,Vector3 rotation,Vector3 position){
		int i = 1;
		Debug.Log ("Receiver id="+id+" posit= "+position.ToString()+" Rotation is "+rotation.ToString());

		if(id!=myId){
			gamem.setCardPosition (i, position, rotation);
			i++;
		}
	}
}
