using UnityEngine;
using UnityEngine.UI;

public class LiveCounter : MonoBehaviour
{
    public Image FoodPrefab;
    public GameObject SpawnPoint;
    private int Lives = 15;

    // Use this for initialization
    void Start()
    {
        InstantiateLives();
    }

    private void InstantiateLives()
    {
        float spaceMultiplier = 50f;
        for (int i = 0; i < Lives; i++)
        {
            var live = Instantiate(FoodPrefab,
                new Vector3(SpawnPoint.transform.position.x + spaceMultiplier * i, SpawnPoint.transform.position.y,
                    0f), Quaternion.identity);
            live.transform.SetParent(SpawnPoint.transform);
            live.tag = "Lives";
        }
    }

    private void DestroyLives()
    {
        var latestLive = GameObject.FindGameObjectsWithTag("Lives");
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
        Lives = Lives + change;
        DestroyLives();
        InstantiateLives();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
