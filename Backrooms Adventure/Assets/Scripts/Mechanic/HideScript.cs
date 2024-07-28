using UnityEngine;

public class HideScript : MonoBehaviour
{
    [SerializeField] private string tagPlayer;
    [SerializeField] private Animator animator;

    private Player _player;
    private bool _isPlayerHide = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(_player != null)
        {
            if (Input.GetKey(KeyCode.E))
            {
                animator.SetBool("hide", true);
                _player.GetCamera.transform.parent = null;
                _isPlayerHide = true;
                _player.gameObject.SetActive(false);
            }

            if (Input.GetKey(KeyCode.Q))
            {
                animator.SetBool("hide", false);
                _player.gameObject.SetActive(true);
                _player.GetCamera.transform.parent = _player.transform;
                _isPlayerHide = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.TryGetComponent<Player>(out Player player))
        {
            _player = player;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player) && 
            _isPlayerHide == false)
        {
            _player = null;
        }
    }
}
