using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour {

    public WaveData waveData;

	void Start () {
        StartCoroutine(waveData.Wave(waveData.timeBetweenWaves));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
