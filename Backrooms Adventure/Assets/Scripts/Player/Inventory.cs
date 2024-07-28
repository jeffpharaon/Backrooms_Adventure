using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject mettallKey;
    [SerializeField] private GameObject goldKey;
    [SerializeField] private GameObject flashLight;
    [SerializeField] private GameObject mindalWater;
    [SerializeField] private GameObject ladder;

    public List<int> inventoryItems = new List<int>();
    private bool isActive = false;

    private int oneMetallKey = 1;
    private int twoGoldKey = 2;
    private int threeFlashLight = 3;
    private int fourMaindalWater = 4;
    private int fiveLadder = 6;

    private void Update() => InventoryLogic();

    private void InventoryLogic()
    {
        if (Input.GetKey(KeyCode.R))
        {
            animator.SetBool("IsInvent", true);
            StartCoroutine(ActivateAfterDelay(0.5f));
        }

        if (Input.GetKey(KeyCode.Q))
        {
            animator.SetBool("IsInvent", false);
            isActive = false;
        }

        if (inventoryItems.Contains(oneMetallKey) && isActive) mettallKey.SetActive(true);
        else mettallKey.SetActive(false);

        if (inventoryItems.Contains(twoGoldKey) && isActive) goldKey.SetActive(true);
        else goldKey.SetActive(false);

        if (inventoryItems.Contains(threeFlashLight) && isActive) flashLight.SetActive(true);
        else flashLight.SetActive(false);

        if (inventoryItems.Contains(fourMaindalWater) && isActive) mindalWater.SetActive(true);
        else mindalWater.SetActive(false);

        if (inventoryItems.Contains(fiveLadder) && isActive) ladder.SetActive(true);
        else ladder.SetActive(false);
    }

    IEnumerator ActivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isActive = true;
    }
}
