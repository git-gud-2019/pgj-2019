using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private int playerHealth = 100;

    public HUD hud;

    public void DoDmg(int dmg)
    {
        playerHealth -= dmg;

        Debug.Log("Player health:" + playerHealth);

        if (playerHealth <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        hud.ChangeState(HUD.State.GAME_OVER);
    }
}
