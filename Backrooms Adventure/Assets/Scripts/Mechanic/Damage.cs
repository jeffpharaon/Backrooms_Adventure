using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damageCol;
    public string colTag;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == colTag)
        {
            Health health = collision.gameObject.GetComponent<Health>();
            health.takeHit(damageCol);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == colTag)
        {
            Health health = collision.gameObject.GetComponent<Health>();
            health.takeHit(damageCol);
        }
    }
}
