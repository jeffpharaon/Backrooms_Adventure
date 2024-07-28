using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Mind : MonoBehaviour
{
    [SerializeField] private Image mind;

    private Inventory inventory;
    public int maxMindStatus = 100;
    public int countAddWater = 100;
    public float _delayMind = 20f;
    public float _delayMindWater = 0.5f;

    private int mindStatus = 100;
    private bool isDrinkMindWater = false;
    private bool isMind = true; 

    private void Start()
    {
        mindStatus = maxMindStatus;
        StartCoroutine(ChangeSpriteAfterDelay(_delayMind));
        StartCoroutine(ChangeMindWater(_delayMindWater));
        inventory = FindObjectOfType<Inventory>();
    }

    private void Update()
    {
        if (inventory.inventoryItems.Contains(4))
        {
            if (Input.GetKey(KeyCode.S))
            {
                isDrinkMindWater = true;
                isMind = false;
                inventory.inventoryItems.Remove(4);
            }
        }
    }

    IEnumerator ChangeSpriteAfterDelay(float delay)
    {
        while (true)
        {
            if (isMind)
            {
                mindStatus -= 1;
                mind.fillAmount = mindStatus / 100.0f;
            }
            yield return new WaitForSeconds(delay);
        }
    }

    IEnumerator ChangeMindWater(float delay)
    {
        while (true)
        {
            if (isDrinkMindWater)
            {
                for(int i = 0; i < countAddWater; i++)
                {
                    mindStatus += 1; 
                    mind.fillAmount = mindStatus / 100.0f;
                    if (mindStatus > 100)
                    {
                        mindStatus = 100;
                        break;
                    }
                    yield return new WaitForSeconds(delay);
                }
                isDrinkMindWater = false;
                isMind = true;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
