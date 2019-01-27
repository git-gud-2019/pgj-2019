using UnityEngine;

public class TrapCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Traps"))
        {
            var trapGameObject = collision.gameObject;

            gameObject.GetComponent<Enemy>().TakeDamage(trapGameObject.GetComponent<TrapBehaviour>().trapDamage);
            trapGameObject.GetComponent<TrapBehaviour>().trapLives--;
        }
    }
}
