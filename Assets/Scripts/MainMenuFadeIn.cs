using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuFadeIn : MonoBehaviour {

    public Material blurMaterial;
    float blurValue = 5;
    public GameObject[] enableThis;

    private void OnDisable()
    {
        blurMaterial.SetFloat("_Size", 0);
    }

    void Update () {
        if (blurValue > 0)
        {
            foreach (GameObject item in enableThis)
            {
                item.SetActive(false);
            }
            blurValue -= 0.04f;
            blurMaterial.SetFloat("_Size", blurValue);
        }
        else
        {
            foreach (GameObject item in enableThis)
            {
                item.SetActive(true);
            }
        }
        
	}
}
