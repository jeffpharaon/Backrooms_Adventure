using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeMonstrViewPlayer : MonoBehaviour
{
    public string tagPlayer;
    private ThreeAttackMonstr attackMonstr;

    private void Start() => attackMonstr = FindObjectOfType<ThreeAttackMonstr>();

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
