using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void singleScene(string scene)
    {
		Debug.Log ("trolololo");
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
