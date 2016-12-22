using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillList : MonoBehaviour{

   public GameObject BtnClone;

    public void fillList()
    {
        var rectTransform = gameObject.GetComponent<RectTransform>();

        for (int i = 0; i < 15; i++)
        {
            GameObject TempBtnClone = Instantiate(BtnClone) as GameObject;
            Text nameItemText = GameObject.Find(TempBtnClone.name + "/TempBtnText").GetComponent<Text>();

            TempBtnClone.name = i.ToString();
            nameItemText.text = i.ToString();

            TempBtnClone.transform.position = new Vector3(0, -30 - i * 60, 0);
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y + 60);
            TempBtnClone.transform.SetParent(gameObject.transform, false);
        }
    }
}
