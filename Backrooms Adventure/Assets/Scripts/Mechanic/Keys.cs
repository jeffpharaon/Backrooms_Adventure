using System.Collections;
using UnityEngine;

public class Keys : MonoBehaviour
{
    [SerializeField] private string tagPlayer; 
    [SerializeField] private Animator animator;
    [SerializeField] private Chest chest;
    [SerializeField] GameObject obj;

    private Inventory inventory;
    public int IdInventoryKeys = 0;
    private bool isActive = false;

    private void Start() => inventory = FindObjectOfType<Inventory>();

    private void Update() => MethodKeys();

    private void  MethodKeys()
    {
        if (chest.checkCollision == true) 
        {
            if (Input.GetKey(KeyCode.E))
                animator.SetBool("IsKeys", true);
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
                    IdInventoryKeys = 1;
                    inventory.inventoryItems.Insert(0, IdInventoryKeys);
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
