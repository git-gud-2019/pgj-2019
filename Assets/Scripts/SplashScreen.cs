using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour {

    public AnimationCurve fadeOutCurve;
    Color temp;

    private void Start()
    {
        temp = GetComponent<Image>().color;
    }

    public void FadeOutEffect()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        var curveTime = 1.0f;
        var curveAmount = fadeOutCurve.Evaluate(curveTime);
        while (curveAmount > 0.0f)
        {
            curveTime -= Time.deltaTime * 3;
            curveAmount = fadeOutCurve.Evaluate(curveTime);
            temp.a = curveAmount * 255;
            GetComponent<Image>().color = temp;
            yield return null;
        }
    }
}
