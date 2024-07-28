using UnityEngine;

public class CheckLadderDialog : MonoBehaviour
{
    [SerializeField] private string tagPlayer;
    [SerializeField] private GameObject obj;

    private LadderDialog ladderDialog;
    private Inventory inventory;
    private bool isCheck = false;

    private void Start()
    {
        ladderDialog = FindObjectOfType<LadderDialog>();
        inventory = FindObjectOfType<Inventory>();
    }

    private void Update()
    {
        if (isCheck)
        {
            if (!inventory.inventoryItems.Contains(6))
            {
                if (Input.GetKey(KeyCode.E))
                {
                    obj.SetActive(true);
                    ladderDialog.dialog.text = string.Empty;
                    ladderDialog.StartDialog();
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
