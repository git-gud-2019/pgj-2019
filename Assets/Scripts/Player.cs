using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public HUD hud;

    public void DoDmg(int dmg)
    {
        hud.Health -= dmg;
        hud.UpdateHealth();

        if (hud.Health <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        hud.ChangeState(HUD.State.GAME_OVER);
    }
}
