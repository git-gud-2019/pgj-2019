using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraReference : MonoBehaviour {

    public SplashScreen referenceScript;

    public void RunMe()
    {
        referenceScript.FadeOutEffect();
    }
}
