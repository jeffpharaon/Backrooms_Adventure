using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private string tagPlayer;
    [SerializeField] Animator animator;

    private Inventory inventory;
    private bool isActive;
    private int scene = 3;

    private void Start() => inventory = FindObjectOfType<Inventory>();

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagPlayer)
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (inventory.inventoryItems.Contains(2))
                {
                    animator.SetBool("DoorOpen", true);
                    StartCoroutine(ActivateAfterDelay(2.5f));

                    if (isActive) SceneManager.LoadScene(scene);
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
