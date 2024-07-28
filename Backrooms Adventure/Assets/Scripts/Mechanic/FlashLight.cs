using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] private string tagPlayer;
    [SerializeField] private GameObject obj;

    private Inventory inventory;
    public int idFlashLight = 0;

    private void Start() => inventory = FindObjectOfType<Inventory>();

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagPlayer)
        {
            if (Input.GetKey(KeyCode.E))
            {
                idFlashLight = 3;
                inventory.inventoryItems.Add(idFlashLight);
                Destroy(this.obj);
            }
        }
    }
}
