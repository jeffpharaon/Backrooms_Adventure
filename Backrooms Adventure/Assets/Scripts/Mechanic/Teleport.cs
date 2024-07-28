using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private string tagPlayer;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagPlayer)
        {
            if (Input.GetKeyDown(KeyCode.W)) 
                collision.gameObject.transform.position = obj.gameObject.transform.position;
        }
    }
}
