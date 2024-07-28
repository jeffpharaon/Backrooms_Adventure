using UnityEngine;

public class ClosedChest : MonoBehaviour
{
    [SerializeField] private string tagPlayer;
    [SerializeField] Animator chest;
    [SerializeField] Animator key;
    [SerializeField] GameObject goldKey;

    private Inventory inventory;
    private bool isGoldKey = false;
    private bool startAnimation = false;

    private void Start() => inventory = FindObjectOfType<Inventory>();

    private void Update()
    {
        CheckGoldKey();

        if (isGoldKey == true) goldKey.SetActive(true);

        else goldKey.SetActive(false);

        if (startAnimation == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                chest.SetBool("chestControll", true);
                key.SetBool("isGoldKeys", true);
            }
        }
    }

    private void CheckGoldKey()
    {
        if (inventory.inventoryItems.Count > 0 && inventory.inventoryItems[0] == 1) isGoldKey = true;
        else isGoldKey = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagPlayer && isGoldKey == true) startAnimation = true;
    }
}
