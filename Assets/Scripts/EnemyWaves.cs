using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour {

    public WaveData waveData;
    private IEnumerable waveCoroutine;

    public int enemyPerWave;

    public int enemiesAlive = 0;
    

    public void StartWave(int waveCount, int enemiesPerWave)
    {
        Debug.Log("StartWave");
        enemyPerWave = enemiesPerWave;
        StartCoroutine(waveData.Wave(waveData.timeBetweenWaves, waveCount));
    }

    public void WaveCompleted()
    {

    }

}
