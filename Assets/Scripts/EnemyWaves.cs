using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour {

    public WaveData waveData;
    private IEnumerable waveCoroutine;

    public int enemyPerWave;
    public int waveCount;

    public int enemiesAlive = 0;
    

    void Start () {
        StartCoroutine(waveData.Wave(waveData.timeBetweenWaves, waveCount));
	}
	
	void Update () {

	}

}
