using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour {

    public WaveData waveData;
    private IEnumerable waveCoroutine;

    public int enemyPerWave;
    public int waveCount;
    

    void Start () {
        StartCoroutine(waveData.Wave(waveData.timeBetweenWaves, waveCount));
	}
	
	void Update () {
		
	}

}
