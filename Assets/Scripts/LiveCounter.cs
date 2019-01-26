using UnityEngine;
using UnityEngine.UI;

public class LiveCounter : MonoBehaviour
{

    public Image TrapPrefab;
    public GameObject SpawnPoint;

    private static string HEALTH_TAG = "Lives";

    void Start()
    {
        InstantiateLives();
    }

    private void InstantiateLives()
    {
        var hud = GetComponent<HUD>();

        var spaceMultiplier = 50f;
        for (var i = 0; i < hud.Health; i++)
        {
            var trap = Instantiate(TrapPrefab,
                new Vector3(SpawnPoint.transform.position.x + spaceMultiplier * i, SpawnPoint.transform.position.y,
                    0f), Quaternion.identity);
            trap.transform.SetParent(SpawnPoint.transform);
            trap.tag = HEALTH_TAG;
        }
    }

    private void DestroyLives()
    {
        var latestLive = GameObject.FindGameObjectsWithTag(HEALTH_TAG);
        if (latestLive.Length > 0)
        {
            foreach (var live in latestLive)
            {
                Destroy(live);
            }
        }
    }

    public void Refresh()
    {
        DestroyLives();
        InstantiateLives();
    }
}
