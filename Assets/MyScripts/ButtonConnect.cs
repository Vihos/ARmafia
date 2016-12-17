using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonConnect : MonoBehaviour {

    void click()
    {
        Debug.Log("Clicked");
    }

    // Use this for initialization
    void Start () {
        Button button = this.GetComponent<Button>();
        button.onClick.AddListener(() => click());
    }
}
