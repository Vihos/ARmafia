using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class StartServerGui : MonoBehaviour {
public InputField RoomName;
	public Dropdown PlayerCount;
	private NetworkView networkview;

	public Canvas ModalWindow;
	public Text ModalTitle;
	public Text ModalReport;
	private string CurrentRoomName = "";
	private const string typeName = "ARMafia";

	private NetworkServerLib networkservlib;

	public void Start()
	{
		networkservlib  = GameObject.Find("NetworkV").GetComponent<NetworkServerLib>();
		networkservlib.findNetworkGui ();
		Debug.Log ("found network server");
		if (networkservlib.IsServer())
		{
			CreateModalWindow("Внимание!", "Сервер уже запущен на вашем устройстве.");
		}
	}

	public void ChangeRoomName()
	{
		CurrentRoomName = RoomName.text;
		networkservlib.ChangeRoomName (RoomName.text);
	}

	public void ChangePlayerCount()
	{
		networkservlib.ChangePlayerCount (PlayerCount.value);
		Debug.Log(PlayerCount.value+3);
	}

	public void CreateModalWindow(string title,string error)
	{
		ModalTitle.text = title;
		ModalReport.text = error;
		ModalWindow.gameObject.SetActive(true);
		Debug.Log("Started modal with text: " + error);
	}

	public void RemoveModalWindow()
	{
		ModalWindow.gameObject.SetActive(false);
		Debug.Log("Removed Modal Window");
	}

	public void HostServer()
	{
		if (CurrentRoomName.Length > 2)
		{
			networkservlib.HostServer ();
		}
		else if (CurrentRoomName.Length < 3)
		{
			CreateModalWindow("Ошибка!", "Имя сервера должно иметь длину не менне 3 символов.");
		}
	}

}
