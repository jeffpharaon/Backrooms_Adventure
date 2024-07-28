using UnityEngine;

public class FlashLightActive : MonoBehaviour
{
    [SerializeField] private GameObject flashLightOn;

    private Inventory inventory;
    private bool isFPressed = false;
    private bool isQPressed = false;

    private void Start() => inventory = FindObjectOfType<Inventory>();

    private void Update()
    {
        CheckFlashLight(3);
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isFPressed = true;
            isQPressed = false;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            isFPressed = false;
            isQPressed = true;
        }
        else if (Input.GetKeyUp(KeyCode.F) || Input.GetKeyUp(KeyCode.Q))
        {
            isFPressed = false;
            isQPressed = false;
        }
    }

    private void CheckFlashLight(int itemID)
    {
        bool hasItem = false;
        foreach (int item in inventory.inventoryItems)
        {
            if (item == itemID)
            {
                hasItem = true;
                break;
            }
        }

        if (hasItem)
        {
            if (isFPressed)
                flashLightOn.SetActive(true);
            else if (isQPressed)
                flashLightOn.SetActive(false);
        }

        else flashLightOn.SetActive(false);
    }
}
