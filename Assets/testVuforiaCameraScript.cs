using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testVuforiaCameraScript : MonoBehaviour {
    public Text myText;
    public GameObject card;
    private float angle;

    private Vector3[] cardPositions = new Vector3[5];
    private Quaternion[] cardRotations = new Quaternion[5];
    private bool isPositionSelected = false;
    private bool isCardShows = false, animate = false;

	void Start () {
        
	}

    void Update()
    {
        if (!isPositionSelected)
        {
            angle = Mathf.PI * this.transform.eulerAngles.y / 180;
            card.transform.position = new Vector3(-1f * Mathf.Sin(angle), card.transform.position.y, -1f * Mathf.Cos(angle));

            myText.text = "" + this.transform.eulerAngles;
        }
        else if (isCardShows)
        {
            card.transform.position = Vector3.Lerp(card.transform.position, new Vector3(card.transform.position.x, 0.5f, card.transform.position.z), 0.25f);
            card.transform.rotation = Quaternion.Lerp(card.transform.rotation, new Quaternion(card.transform.rotation.x, card.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w), 0.25f);
        }
        else if (!isCardShows)
        {
            card.transform.position = Vector3.Lerp(card.transform.position, cardPositions[0], 0.25f);
            card.transform.rotation = Quaternion.Lerp(card.transform.rotation, cardRotations[0], 0.25f);
        }
	}

    public void submitMyCardPosition()
    {
        if (!isPositionSelected)
        {
            cardPositions[0] = card.transform.position;
            cardRotations[0] = card.transform.rotation;
            isPositionSelected = true;
            Debug.Log("Setted");
        }
        else if (!isCardShows)
        {
            Debug.Log("isCardShows true");
            isCardShows = true;
        }
        else if (isCardShows)
        {
            Debug.Log("isCardShows false");
            isCardShows = false;
        }
    }
}
