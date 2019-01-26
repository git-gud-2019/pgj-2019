using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int playerHealth = 100;

    private void Update()
    {
        Debug.Log("Player health:" + playerHealth);

        if (playerHealth <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {

    }
}
