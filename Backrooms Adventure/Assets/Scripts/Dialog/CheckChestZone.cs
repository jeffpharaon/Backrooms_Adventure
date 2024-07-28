using UnityEngine;

public class CheckChestZone : MonoBehaviour
{
    [SerializeField] private string tagPlayer;
    [SerializeField] private GameObject obj;

    private ChestDialog chestDialog;
    private Inventory inventory;
    private bool iSCheck = false;

    private void Start()
    {
        chestDialog = FindObjectOfType<ChestDialog>();
        inventory = FindObjectOfType<Inventory>();
    }

    private void Update()
    {
        if (iSCheck == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (inventory.inventoryItems.Contains(1)) obj.SetActive(false);

                else
                {
                    obj.SetActive(true);
                    chestDialog.dialog.text = string.Empty;
                    chestDialog.StartDialog();
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagPlayer) iSCheck = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagPlayer) iSCheck = false;
    }
}
