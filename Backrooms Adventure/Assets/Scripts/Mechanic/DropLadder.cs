using UnityEngine;
using System.Collections;

public class DropLadder : MonoBehaviour
{
    [SerializeField] private string tagPlayer;
    [SerializeField] private Animator animator;
    [SerializeField] private Chest chest;
    [SerializeField] GameObject obj;

    private Inventory inventory;
    public int IdInventoryLadder = 0;
    private bool isActive = false;

    private void Start() => inventory = FindObjectOfType<Inventory>();

    private void Update() => MethodLadder();

    private void MethodLadder()
    {
        if (chest.checkCollision == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                StartCoroutine(ActivateAfterDelay(1f));
                animator.SetBool("IsDropLadder", true);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagPlayer)
        {
            if (Input.GetKey(KeyCode.E))
            {
                StartCoroutine(ActivateAfterDelay(2.5f));

                if (isActive)
                {
                    IdInventoryLadder = 6;
                    inventory.inventoryItems.Add(IdInventoryLadder);
                    Destroy(this.obj);
                }
            }
        }
    }

    IEnumerator ActivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isActive = true;
    }
}
