using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrapBehaviour : MonoBehaviour {

    public int trapLives = 3;
    public int trapDamage = 30;
    public Text trapLivesText;

	void Start () {
        trapLivesText = this.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>();
	}
	
	void Update () {
        trapLivesText.text = trapLives.ToString();

        if (trapLives == 0)
        {
            Destroy(this.gameObject);
        }
	}
}
