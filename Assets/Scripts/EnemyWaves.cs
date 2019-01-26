using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour {

    public WaveData waveData;
    public HUD hud;
    private IEnumerable waveCoroutine;
    

    public void StartWave(int waveCount, int enemiesPerWave, float interval)
    {
        Debug.Log("StartWave");
        StartCoroutine(waveData.Wave(enemiesPerWave, waveCount, interval));
    }

    public void WaveCompleted()
    {
        Debug.Log("Waves Done");
        hud.ChangeState(HUD.State.PREPARING);
    }

    public void KillEnemy()
    {
        Debug.Log("Kill Enemy");
        waveData.KillEnemy();
    }

}
