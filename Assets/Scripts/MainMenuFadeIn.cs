using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuFadeIn : MonoBehaviour {

    public Material blurMaterial;
    float blurValue = 5;

	void Start () {
		
	}
	
	void Update () {
        if (blurValue > 0)
        {
            blurValue -= 0.04f;
            blurMaterial.SetFloat("_Size", blurValue);
        }
        
	}
}
