using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject Parentpath;
    List<GameObject> path;
    public int health = 100;
    public Image healthUI;
    public float speed;
    public int enemyDamage;

    private void Start()
    {
        path = new List<GameObject>();
        foreach (Transform child in Parentpath.transform)
        {
            path.Add(child.gameObject);
        }
        StartCoroutine(GoOnPath());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            health -= 10;
            healthUI.fillAmount -= 0.1f;
        }

        if(health <= 0)
        {
            GameObject.FindGameObjectWithTag("EnemySpawn").GetComponent<EnemyWaves>().KillEnemy();
            Destroy(gameObject);
        }

        if (!path.Any())
        {
            var player = GameObject.Find("Main Camera").GetComponent<Player>();
                player.DoDmg( enemyDamage);
            GameObject.FindGameObjectWithTag("EnemySpawn").GetComponent<EnemyWaves>().KillEnemy();
            Destroy(gameObject);
        }
    }

    IEnumerator GoOnPath()
    {
        if (path.Count > 0)
        {
            if (gameObject.CompareTag("EnemyFlipAll"))
            {
                if (transform.position.y == path[0].transform.position.y)
                {

                    if (transform.position.x < path[0].transform.position.x)
                    {
                        transform.rotation = Quaternion.Euler(Vector3.forward * 270);
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(Vector3.forward * 90);
                    }
                }
                else
                {
                    if (transform.position.y < path[0].transform.position.y)
                    {
                        transform.rotation = Quaternion.Euler(Vector3.forward * 0);
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(Vector3.forward * 180);
                    }
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, path[0].transform.position, speed * Time.deltaTime);
            if (transform.position == path[0].transform.position)
            {
                path.RemoveAt(0);
            }
            yield return null;
            StartCoroutine(GoOnPath());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Traps"))
        {
            health -= 30;
            healthUI.fillAmount -= 0.3f;
            Destroy(collision.gameObject);
        }
    }
}
