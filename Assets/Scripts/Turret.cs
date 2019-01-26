using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform Target;
    public float Range = 2f;

    private string EnemyTag = "EnemyFlipAll";
//    public Transform PartToRotate;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= Range)
        {
            Target = nearestEnemy.transform;
        }
        else
        {
            Target = null;
        }
    }

    void Update()
    {
        if (Target == null)
        {
            return;
        }

        Vector3 direction =
            Target.position -
            transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = lookRotation.eulerAngles;
        float lookRotationX;
        if (lookRotation.y < 0)
        {
            lookRotationX = rotation.x + 270;
        }
        else
        {
            lookRotationX = rotation.x * -1 + 90;
        }
        transform.rotation = Quaternion.Euler(lookRotationX, 270f, 90f);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
