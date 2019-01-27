using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.PostProcessing;

public class CameraReference : MonoBehaviour {

    public SplashScreen referenceScript;
    public PostProcessingProfile otherProfile;

    public void RunMe()
    {
        referenceScript.FadeOutEffect();
    }

    public void RemovePPS()
    {
        Camera.main.GetComponent<PostProcessingBehaviour>().profile = otherProfile;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
