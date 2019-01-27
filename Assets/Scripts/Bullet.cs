using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform Target;
    public float Speed = 1f;
    public float Damage = 30f;
    public GameObject ImpactEffect;

    public void Seek(Transform target)
    {
        Target = target;
    }

    void Update()
    {
        if (Target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = Target.position - transform.position;
        float distanceThisFrame = Speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    private void HitTarget()
    {
        GameObject effectInst = Instantiate(ImpactEffect, transform.position, transform.rotation);
        Destroy(effectInst, 1);
        Destroy(gameObject);
        Target.GetComponent<Enemy>().TakeDamage(Damage);
    }
}
