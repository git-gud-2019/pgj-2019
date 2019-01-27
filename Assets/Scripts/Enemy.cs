using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject Parentpath;
    public GameObject Hud;
    List<GameObject> path;
    public float health = 100;
    public float InitialHealth;
    public Image healthUI;
    public float speed;
    public int enemyDamage;
    private float initialSpeed;
    public int CoinDropNumber = 1;

    public Text damageRecievedText;

    private void Start()
    {
        damageRecievedText.text = "";

        initialSpeed = speed;
        InitialHealth = health;

        path = new List<GameObject>();
        foreach (Transform child in Parentpath.transform)
        {
            path.Add(child.gameObject);
        }

        StartCoroutine(GoOnPath());
    }

    private void Update()
    {
        UpdateHealthUI();

        if (health <= 0)
        {
            Die();
        }

        if (!path.Any())
        {
            var player = GameObject.Find("Main Camera").GetComponent<Player>();
            player.DoDmg(enemyDamage);
            GameObject.FindGameObjectWithTag("EnemySpawn").GetComponent<EnemyWaves>().KillEnemy();
            Destroy(gameObject);
        }
    }

    private void Die()
    {
        GameObject.FindGameObjectWithTag("EnemySpawn").GetComponent<EnemyWaves>().KillEnemy();
        Destroy(gameObject);
        DropCoin();
    }

    private void DropCoin()
    {
        Hud.GetComponent<HUD>().ChangeCoins(CoinDropNumber);
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

            transform.position =
                Vector2.MoveTowards(transform.position, path[0].transform.position, speed * Time.deltaTime);
            if (transform.position == path[0].transform.position)
            {
                path.RemoveAt(0);
            }

            yield return null;
            StartCoroutine(GoOnPath());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Traps"))
        {
            health -= collision.gameObject.GetComponent<TrapBehaviour>().trapDamage;
            speed /= 2;
            if (speed <= initialSpeed / 2)
            {
                speed = initialSpeed / 2;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        var realDamage = CalculateDamage(damage);

        DisplayDamage(realDamage);
        health -= realDamage;
    }

    private void UpdateHealthUI()
    {
        healthUI.fillAmount = health / InitialHealth;
    }

    private float CalculateDamage(float damage)
    {
        return (damage + (Random.Range(damage * 0.08f, -damage * 0.08f)));
    }

    private void DisplayDamage(float damage)
    {
        damageRecievedText.gameObject.GetComponent<DestroyDamageText>().time = 0f;
        //damageRecievedText.text = "-" + Mathf.RoundToInt(damage).ToString();

        damageRecievedText.text = string.Format("-{0}", (int)damage);

    }
}
