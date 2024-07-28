using UnityEngine;

public class LearnList : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private string tagPlayer;

    private bool isActive = false;

    private void Update()
    {
        if (isActive == true)
        {
            if (Input.GetKey(KeyCode.E))
                obj.SetActive(true);

            if (Input.GetKey(KeyCode.Q))
                obj.SetActive(false);
        }

        else obj.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagPlayer) isActive = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagPlayer) isActive = false;
    }
}
