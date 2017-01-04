using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPosition : MonoBehaviour {

    public GameObject card;

	void Start ()
    {
        
    }
	
	void Update ()
    {
        card.transform.rotation = new Quaternion(card.transform.rotation.x, card.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w);
        //this.transform.rotation = new Quaternion(this.transform.rotation.x, -camera.transform.rotation.y, camera.transform.rotation.z, this.transform.rotation.w);
        //this.transform.position = new Vector3((this.transform.position.x + camera.transform.position.x) / 3, this.transform.position.y, (this.transform.position.z + camera.transform.position.z) / 3);
        //Debug.Log(camera.transform.rotation);
	}
}
