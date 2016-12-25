using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.
using UnityEngine.SceneManagement;

public class ConnectServerGui : MonoBehaviour {

	public HostData[] hostList;
	public GameObject ButtonClone; // Init Button Clone Object
	public GameObject ServersList; // Init Parent for Button Clone Object
    public GameObject RefreshConnectModal;

	public Canvas ModalWindow;
	public Text ModalTitle;
	public Text ModalReport;
	private NetworkCLientLib networklib;
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
        networklib  = GameObject.Find("NetworkV").GetComponent<NetworkCLientLib>();
		if (networklib.isClient())
		{
			SceneManager.LoadScene("lobby", LoadSceneMode.Single);
		}
		Debug.Log ("Starting refresh");
		networklib.RefreshServerList();
		networklib.FindGui();
	}

    public void refreshButtonClick()
    {
        createModalRefresh();
        networklib.RefreshServerList();
    }

    public void createModalRefresh()
    {
        RefreshConnectModal.SetActive(true);
    }

    public void remooveModalRefresh()
    {
        RefreshConnectModal.SetActive(false);
    }

	public void GenerateServerButtons(HostData[] hostList)
	{
		// Init variable for ServersList Object to change size of list
		var rectTransform = ServersList.GetComponent<RectTransform>();

        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, 0);

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
			TempButtonCloneButtonObject.onClick.AddListener(() => networklib.JoinServer(this.name));
        }
    }

	void OnConnectedToServer()
	{
		//CreateModalWindow("Клиент", "Вы успешно подключились к серверу");
		//SceneManager.LoadScene("lobby", LoadSceneMode.Single);
	}

	[RPC]
	public void Change(string texto)
	{
		Application.LoadLevel(texto);
		//Debug.Log("trololololololololo");
	}
}
