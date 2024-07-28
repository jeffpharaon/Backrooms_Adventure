using System.Collections;
using UnityEngine;

public class GoldKey : MonoBehaviour
{
    [SerializeField] private string tagPlayer;
    [SerializeField] GameObject obj;

    private Inventory inventory;
    private bool isActive = false;

    private void Start() => inventory = FindObjectOfType<Inventory>();

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagPlayer)
        {
            if (Input.GetKey(KeyCode.E))
            {
                StartCoroutine(ActivateAfterDelay(2.5f));

                if (isActive)
                {
                    int idInventoryGoldKeys = 2;
                    inventory.inventoryItems.Add(idInventoryGoldKeys);
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
