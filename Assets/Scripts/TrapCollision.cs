using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCollision : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Traps")
        {
            var trapGO = collision.gameObject;
            this.gameObject.GetComponent<Enemy>().health -= trapGO.GetComponent<TrapBehaviour>().trapDamage;
            this.gameObject.GetComponent<Enemy>().healthUI.fillAmount -= 0.3f;
            trapGO.GetComponent<TrapBehaviour>().trapLives--;
        }
    }

}
