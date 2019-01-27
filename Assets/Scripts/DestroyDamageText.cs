using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyDamageText : MonoBehaviour {

    public float time = 0;

    private void Update()
    {
        time += 1;

        if (time == 100)
        {
            this.gameObject.GetComponent<Text>().text = "";
        }
    }
}
