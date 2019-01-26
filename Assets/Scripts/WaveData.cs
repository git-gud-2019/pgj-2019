using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveData", menuName = "Waves/Data", order = 1)]
public class WaveData : ScriptableObject {

    [SerializeField]
    public Transform[] enemies;
    public int cicle;
    public float spawnInterval;
}
