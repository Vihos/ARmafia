using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviour
{
	public NetworkView networkview;
    public HostData[] hostList;
    public GameObject ButtonClone; // Init Button Clone Object
    public GameObject ServersList; // Init Parent for Button Clone Object

    public Canvas ModalWindow;
    public Text ModalTitle;
    public Text ModalReport;

    public void CreateModalWindow(string title, string error)
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

    private void Start()
    {
        if (Network.isClient)
        {
            SceneManager.LoadScene("lobby", LoadSceneMode.Single);
        }

        RefreshServerList();
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
            hostList = MasterServer.PollHostList();
            GenerateServerButtons();
        }
    }

    public void GenerateServerButtons()
    {
        // Init variable for ServersList Object to change size of list
        var rectTransform = ServersList.GetComponent<RectTransform>();

        for (int i = 0; i < hostList.Length; i++)
        {
            // Creating Button Clone as a Gamebject on scene
            GameObject TempButtonCloneGameObject = Instantiate(ButtonClone) as GameObject;

            Button TempButtonCloneButtonObject = TempButtonCloneGameObject.GetComponent<Button>();
            // Finding Button Text Object
            Text ButtonCloneText = GameObject.Find(TempButtonCloneGameObject.name + "/TempBtnText").GetComponent<Text>();

            // Giving Name for ButtonObject and changint Text on the button
            TempButtonCloneGameObject.name = i.ToString();
            ButtonCloneText.text = hostList[i].gameName;

            // Making ServerList larger
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y + 60);
            // Moving Button
            TempButtonCloneGameObject.transform.position = new Vector3(0, -30 - i * 60, 0);
            // Making parent for Button Clone (ServersList)
            TempButtonCloneGameObject.transform.SetParent(ServersList.transform, false);

            //Adding Listener
            TempButtonCloneButtonObject.onClick.AddListener(() => JoinServer(this.name));
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
        CreateModalWindow("Клиент", "Вы успешно подключились к серверу");
        //SceneManager.LoadScene("lobby", LoadSceneMode.Single);
		networkview.RPC("messageFromServer",RPCMode.All, "You was been detected from server");
    }

	[RPC]
	void messageFromServer(string texto)
	{
		Debug.Log(texto);
	}
}
