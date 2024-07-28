using UnityEngine;

public class CheckDoorDialog : MonoBehaviour
{
    [SerializeField] private string tagPlayer;
    [SerializeField] private GameObject obj;

    private DoorDialog doorDialog;
    private Inventory inventory;
    private bool isCheck = false;

    private void Start()
    {
        doorDialog = FindObjectOfType<DoorDialog>();
        inventory = FindObjectOfType<Inventory>();
    }

    private void Update()
    {
        if (isCheck)
        {
            if (!inventory.inventoryItems.Contains(2))
            {
                if (Input.GetKey(KeyCode.E))
                {
                    obj.SetActive(true);
                    doorDialog.dialog.text = string.Empty;
                    doorDialog.StartDialog();
                }
            }

            else obj.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagPlayer) isCheck = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagPlayer) isCheck = false;
    }
}
