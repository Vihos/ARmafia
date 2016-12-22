using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VuforiaCameraTest : MonoBehaviour {

    public GameObject card;
    public Text markerPosText;
    public Text cameraPosText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        //card.transform.position = new Vector3(card.transform.position.x, 100f, card.transform.position.z);
        //card.transform.rotation = new Quaternion (card.transform.rotation.x, card.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w);

        //markerPosText.text = "Marker rotation x = " + this.transform.rotation.x.ToString() + " y =  "+ this.transform.rotation.y.ToString() + " z = " + this.transform.rotation.z.ToString();
        //cameraPosText.text = "Camera position: " + this.transform.position.ToString();

        //card.transform.position = new Vector3(0f,100f,0f);


        //Debug.Log(this.transform.rotation);
        //Debug.Log(this.transform.position);
        //z
        //cube.transform.position = new Vector3(100,0,190);
        //cube.transform.rotation = new Quaternion(45f,45f,45f,1f);
    }
}
