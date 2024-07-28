using UnityEngine;

public class ActiveLadder : MonoBehaviour
{
    [SerializeField] private string tagPlayer;

    [SerializeField] GameObject ladder1;
    [SerializeField] GameObject ladder2;
    [SerializeField] GameObject ladder3;
    [SerializeField] GameObject ladder4;

    private Inventory inventory;
    private bool isActive = false;

    private void Start() => inventory = FindObjectOfType<Inventory>();

    private void Update()
    {
        if (isActive == true)
        {
            if (inventory.inventoryItems.Contains(6))
            {
                ladder1.SetActive(true);
                ladder2.SetActive(true);
                ladder3.SetActive(true);
                ladder4.SetActive(true);

                inventory.inventoryItems.Remove(6);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagPlayer) 
        { 
            if (Input.GetKey(KeyCode.E))
            {
                isActive = true;
            }
        }
    }
}
