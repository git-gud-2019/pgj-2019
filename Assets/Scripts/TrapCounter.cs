using UnityEngine;
using UnityEngine.UI;

public class TrapCounter : MonoBehaviour {

    public Image TrapPrefab;
    public GameObject SpawnPoint;
    private int Traps = 1;

    // Use this for initialization
    void Start()
    {
        InstantiateLives();
    }

    private void InstantiateLives()
    {
        float spaceMultiplier = 50f;
        for (int i = 0; i < Traps; i++)
        {
            var trap = Instantiate(TrapPrefab,
                new Vector3(SpawnPoint.transform.position.x + spaceMultiplier * i, SpawnPoint.transform.position.y,
                    0f), Quaternion.identity);
            trap.transform.SetParent(SpawnPoint.transform);
            trap.tag = "Traps";
        }
    }

    private void DestroyLives()
    {
        var latestLive = GameObject.FindGameObjectsWithTag("Traps");
        if (latestLive.Length > 0)
        {
            foreach (var live in latestLive)
            {
                Destroy(live);
            }
        }
    }

    public void ChangeLives(int change)
    {
        Traps = Traps + change;
        DestroyLives();
        InstantiateLives();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
