using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private string tagPlayer;
    [SerializeField] private Animator animator;

    public bool checkCollision = false;

    private void Update()
    {
        if (checkCollision == true)
        {
            if (Input.GetKey(KeyCode.E)) 
                animator.SetBool("chestControll", true);
        }

        else animator.SetBool("chestControll", false);

        if (Input.GetKey(KeyCode.Q))
        {
            checkCollision = false;
            animator.SetBool("chestControll", false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagPlayer) checkCollision = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagPlayer) checkCollision = false;
    }
}
