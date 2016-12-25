using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testVuforiaCameraScript : MonoBehaviour {
    private Animator anim;
    public GameObject card;
    private float angle;

    private Vector3[] cardPositions = new Vector3[5];
    private Vector3[] cardRotations = new Vector3[5];
    private bool isPositionSelected = false;
    private bool isCardShows = false, animate = false;

	void Start () {
        
    }

    void Update()
    {
        if (!isPositionSelected)
        {
            angle = Mathf.PI * this.transform.eulerAngles.y / 180;

            card.transform.eulerAngles = new Vector3(card.transform.eulerAngles.x, this.transform.eulerAngles.y, card.transform.eulerAngles.z);
            card.transform.position = new Vector3(-1f * Mathf.Sin(angle), card.transform.position.y, -1f * Mathf.Cos(angle));
        }

        //card.transform.position = Vector3.Lerp(card.transform.position, new Vector3(card.transform.position.x, 0.5f, card.transform.position.z), 0.25f);
        //card.transform.position = Vector3.Lerp(card.transform.position, cardPositions[0], 0.25f);
	}

    public void submitMyCardPosition()
    {
        if (!isPositionSelected)
        {
            cardPositions[0] = card.transform.position;
            cardRotations[0] = card.transform.eulerAngles;

            Destroy(GameObject.Find("InfoWindow"));

            isPositionSelected = true;
            Debug.Log("Setted");
        }
        else if (!isCardShows)
        {
            card.transform.position = new Vector3(card.transform.position.x, 0.5f, card.transform.position.z);
            card.transform.eulerAngles = new Vector3(210f, card.transform.eulerAngles.y, card.transform.eulerAngles.z);

            isCardShows = true;
            Debug.Log("isCardShows true");
        }
        else if (isCardShows)
        {
            card.transform.position = new Vector3(card.transform.position.x, 0f, card.transform.position.z);
            card.transform.eulerAngles = new Vector3(cardRotations[0].x, card.transform.eulerAngles.y, card.transform.eulerAngles.z);

            isCardShows = false;
            Debug.Log("isCardShows false");
        }
    }
}
