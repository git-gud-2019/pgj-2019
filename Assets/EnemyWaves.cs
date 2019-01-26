using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour {

    public WaveData waveData;
    private IEnumerable waveCoroutine;
    public float timeBetweenWaves;
    public int waveCount;

	void Start () {
        StartCoroutine(waveData.Wave(timeBetweenWaves, waveCount));
	}
	
	void Update () {
		
	}

}
