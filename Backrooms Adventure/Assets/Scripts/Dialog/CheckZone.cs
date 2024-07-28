using UnityEngine;

public class CheckZone : MonoBehaviour
{
    [SerializeField] private string tagPlayer;

    private DialogLogic dialogLogic;

    private void Start() => dialogLogic = FindObjectOfType<DialogLogic>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagPlayer)
        {
            dialogLogic.dialog.text = string.Empty;
            dialogLogic.StartDialog();
        }
    }
}
