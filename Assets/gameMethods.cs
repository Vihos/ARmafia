using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameMethods : MonoBehaviour {

    private GameObject tempCard;

    void Start () {
        
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

    public void setDayTimer()
    {

    }

    public void setNightTimer()
    {

    }
}
