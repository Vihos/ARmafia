using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class NetworkServerLib : MonoBehaviour {


	public NetworkView networkview;
	private string CurrentRoomName = "";
	private int CurrentPlayerCount = 3;
	private const string typeName = "ARMafia";
	private StartServerGui startServerGui;
	List<int> usersIds = new List<int>();
	private bool isDay = true;
	private int timer=0;
	private int max=20;
	private bool firstJoined=false;

	Dictionary<int, Vector3> vectorsRotation = new Dictionary<int, Vector3>();
	Dictionary<int, Vector3> vectorsPosition = new Dictionary<int, Vector3>();

	public void Start()
	{
		
	}
	public void findNetworkGui(){
		startServerGui  = GameObject.Find("NetworkV").GetComponent<StartServerGui>();
	}
	public bool IsServer(){
		return Network.isServer;
	}
	public void ChangePlayerCount(int value)
	{
		CurrentPlayerCount = value+3;
		Debug.Log(value+3);
	}

	public void ChangeRoomName(string text)
	{
		CurrentRoomName = text;
	}

	public void HostServer()
	{
		Network.InitializeServer(CurrentPlayerCount, 25000, !Network.HavePublicAddress());
		MasterServer.RegisterHost(typeName, CurrentRoomName);
		Debug.Log("Server Started!");
	}

	void OnServerInitialized()
	{
		Debug.Log("Server Initializied");
	}

	void OnConnectedToServer()
	{
		networkview = GameObject.Find("NetworkV").GetComponent<NetworkView>();
		networkview.RPC("Change",RPCMode.AllBuffered, "VuforiaPositionsTest");

	}
	void listIds(){
		string str = "";
		foreach(int elem in usersIds ){
			str += elem +" and";
		}
		Debug.Log ("Now are connected "+str);
	}


	[RPC]
	public void AddClient(int id, string str)
	{
		if (str == "Armafia") {
			usersIds.Add (id);
			Debug.Log ("User with id " + id + " has joined");
			listIds ();
		}
		if(!firstJoined){
			firstJoined = true;
			Invoke ("UpdateTimer", 0);
		}
	}

	public void UpdateTimer(){

		if (timer > 0) {
			if (isDay) {
				Invoke ("UpdateTimer", 1);
				timer--;
			} else {
				Invoke ("UpdateTimer", 1);
				timer--;
			}
		} else {
			isDay = !isDay;
			timer = max;
			Invoke ("UpdateTimer", 0);
			if (isDay) {
				networkview.RPC("SetDay",RPCMode.AllBuffered);
			} else {
				networkview.RPC("SetNight",RPCMode.AllBuffered);
			}
		}
	}
	//vectorsRotation
	//vectorsPosition
	[RPC]
	public void AceptCoords(int myId,Vector3 v31,Vector3 v32){
		if (usersIds.Contains (myId)) {
			if(!vectorsRotation.ContainsKey(myId)){
				vectorsRotation.Add (myId, v31);
			}
		}
		if (usersIds.Contains (myId)) {
			if(!vectorsPosition.ContainsKey(myId)){
				vectorsPosition.Add (myId, v32);
			}
		}
		if (usersIds.Count > 0) {
			SendCoordsToUsers (vectorsRotation,vectorsPosition);
		}

	}

	public void SendCoordsToUsers(Dictionary<int, Vector3> rotations,Dictionary<int, Vector3> positions){
		
		foreach (int elem in rotations.Keys) {
			Debug.Log ("Sending="+elem+" posit= "+positions[elem].ToString()+" Rotation is "+rotations[elem]);
			networkview.RPC("SendCoordsUsers",RPCMode.OthersBuffered, elem, positions[elem], rotations[elem]);
		}
	}
}
