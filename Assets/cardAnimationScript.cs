using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardAnimationScript : MonoBehaviour {

    Animator anim;
    int show = Animator.StringToHash("Base Layer.show");
    int hide = Animator.StringToHash("hide");

    void Start () {
        anim = GetComponent<Animator>();
    }
	
	void Update () {
        anim.SetTrigger(show);
    }
}
