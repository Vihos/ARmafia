using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class CreateServer : MonoBehaviour {

    public InputField RoomName;
    public Dropdown PlayerCount;
    private NetworkView networkview;

    public Canvas ModalWindow;
    public Text ModalTitle;
    public Text ModalReport;
	GameObject go;
    private string CurrentRoomName = "";
    private int CurrentPlayerCount = 3;
    private const string typeName = "ARMafia";
    public void Start()
    {

        if (Network.isServer)
        {
            CreateModalWindow("Внимание!", "Сервер уже запущен на вашем устройстве.");
        }
    }

    public void ChangeRoomName()
    {
        CurrentRoomName = RoomName.text;
    }

    public void ChangePlayerCount()
    {
        CurrentPlayerCount = PlayerCount.value+3;
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
            Network.InitializeServer(CurrentPlayerCount, 25000, !Network.HavePublicAddress());
            MasterServer.RegisterHost(typeName, CurrentRoomName);
            Debug.Log("Server Started!");
        }
        else if (CurrentRoomName.Length < 3)
        {
            CreateModalWindow("Ошибка!", "Имя сервера должно иметь длину не менне 3 символов.");
        }
    }

    void OnServerInitialized()
    {
        Debug.Log("Server Initializied");
    }

	void OnConnectedToServer()
	{
		networkview = GameObject.Find("ClientScripts").GetComponent<NetworkView>();
		networkview.RPC("Change",RPCMode.AllBuffered,"Vuforia");
	}
}
