using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public List<GameObject> path;
    int health = 100;
    public Image healthUI;

    private void Start()
    {
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
            Destroy(gameObject);
        }
    }

    IEnumerator GoOnPath()
    {
        if (path.Count > 0)
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
            transform.position = path[0].transform.position;
            path.RemoveAt(0);
            yield return new WaitForSecondsRealtime(0.2f);
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
