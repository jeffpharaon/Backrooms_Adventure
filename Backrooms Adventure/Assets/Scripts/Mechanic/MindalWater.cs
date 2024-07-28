using System.Collections;
using UnityEngine;

public class MindalWater : MonoBehaviour
{
    [SerializeField] private string tagPlayer;
    [SerializeField] private Animator animator;
    [SerializeField] private Chest chest;
    [SerializeField] GameObject obj;

    private Inventory inventory;
    public int IdInventoryWater = 0;
    private bool isActive = false;

    private void Start() => inventory = FindObjectOfType<Inventory>();

    private void Update() => MethodMindalWater();

    private void MethodMindalWater()
    {
        if (chest.checkCollision == true)
        {
            if (Input.GetKey(KeyCode.E))
                animator.SetBool("IsWater", true);
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
                    IdInventoryWater = 4;
                    inventory.inventoryItems.Add(IdInventoryWater);
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
