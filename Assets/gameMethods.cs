using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameMethods : MonoBehaviour {

    private GameObject tempCard;
	private NetworkCLientLib networklib;
	private GameObject imgtrg;
    void Start () {
		networklib  = GameObject.Find("NetworkV").GetComponent<NetworkCLientLib>();
		networklib.FindGameMethos();
    }
	
	void Update () {
        
    }

    public void setCardPosition (int id, Vector3 position, Vector3 rotation) // id (0-2)
    {
        tempCard = GameObject.Find(id.ToString());
        tempCard.transform.position = position;
        tempCard.transform.eulerAngles = rotation;
        Debug.Log("Transformed card: " + id + " to positions " + position + " with rotations " + rotation);
    }

	public void sendPositionToServer() // id (0-2)
	{
		imgtrg = GameObject.Find ("ImageTarget/0");
		networklib.sendToServer(imgtrg.transform.eulerAngles,imgtrg.transform.position);
	}
}
