using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveData", menuName = "Waves/Data", order = 1)]
public class WaveData : ScriptableObject
{

    [SerializeField]
    public Transform[] enemies;
    public int cicle;
    public int enemiesPerWave;
    public float spawnInterval;
    public float timeBetweenWaves;
    public List<GameObject> path;


    public IEnumerator Wave(float timeBetweenWaves)
    {
        for (var i = 0; i < enemiesPerWave; i++)
        {
            var enemyGO = enemies[Random.Range(0, 1)];
            var go = Instantiate(enemyGO, GameObject.FindGameObjectWithTag("SpawnPoint").transform.position, Quaternion.identity);
            go.GetComponent<Enemy>().path = path;
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
