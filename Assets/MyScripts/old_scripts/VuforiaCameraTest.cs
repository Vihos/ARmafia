using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VuforiaCameraTest : MonoBehaviour {

    public GameObject card;
    public Text markerPosText;
    public Text cameraPosText;
    private float angle;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        angle = Mathf.PI * Quaternion.Angle(card.transform.rotation, this.transform.rotation) / 180;

        //card.transform.position = new Vector3(card.transform.position.x, 100f, card.transform.position.z);
        card.transform.rotation = new Quaternion (card.transform.rotation.x, card.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w);

        card.transform.position = new Vector3(-150f * Mathf.Sin(Mathf.PI * this.transform.eulerAngles.y / 180), card.transform.position.y, -150f * Mathf.Cos(Mathf.PI * this.transform.eulerAngles.y / 180));

        //card.transform.Rotate(Vector3.zero, .51f);

        //card.transform.RotateAround(Vector3.zero, new Vector3(0f, 0f, 1f), 1f);

        //Debug.Log(Mathf.Cos(3.14f * this.transform.rotation.z));
        // - 100f * Mathf.Cos(3.14f * this.transform.rotation.z)
        // 100f * Mathf.Cos(6.28f * this.transform.rotation.z)

        //x = - 150f * Mathf.Sin(Mathf.PI * this.transform.rotation.z * (this.transform.rotation.x / Mathf.Abs(this.transform.rotation.x)));
        //x = -150f * Mathf.Cos(Mathf.PI * this.transform.rotation.z);
        //y = -150f * Mathf.Sin(Mathf.PI * this.transform.rotation.z);

        //y = - 150f * Mathf.Cos(Mathf.PI * this.transform.rotation.z * (this.transform.rotation.x / Mathf.Abs(this.transform.rotation.x)));

        //card.transform.position = new Vector3(x, y, 0f);
        
        //card.transform.position = new Vector3 (-200 * Mathf.Cos(3.14f * this.transform.rotation.z), 200 * Mathf.Sin(3.14f*this.transform.rotation.z), card.transform.position.z);

        markerPosText.text = "Marker rotation " + /*this.transform.rotation.x.ToString() + " y =  "+ this.transform.rotation.y.ToString() + */" z = " + this.transform.rotation.z.ToString();
        cameraPosText.text = "Camera position: " + this.transform.position.ToString();

        //card.transform.position = new Vector3(0f,100f,0f);


        //Debug.Log(this.transform.rotation);
        //Debug.Log(this.transform.position);
        //z
        //cube.transform.position = new Vector3(100,0,190);
        //cube.transform.rotation = new Quaternion(45f,45f,45f,1f);
    }
}
