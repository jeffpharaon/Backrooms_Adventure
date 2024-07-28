using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoMonstrViewPlayer : MonoBehaviour
{
    public string tagPlayer;
    private TwoAttackMonstr attackMonstr;

    private void Start() => attackMonstr = FindObjectOfType<TwoAttackMonstr>();

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
