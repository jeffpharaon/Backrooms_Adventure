using UnityEngine;

public class MonstrViewPlayer : MonoBehaviour
{
    public string tagPlayer;
    private AttackMonstr attackMonstr;

    private void Start() => attackMonstr = FindObjectOfType<AttackMonstr>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == tagPlayer)
        {
            attackMonstr.AttackOn();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == tagPlayer)
        {
            attackMonstr.AttackFalse();
        }
    }
}
