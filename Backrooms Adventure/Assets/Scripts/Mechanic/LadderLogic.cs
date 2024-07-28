using UnityEngine;

public class LadderLogic : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float distance;
    [SerializeField] private LayerMask layerMask;

    private float InputVertical;
    private bool climbing;

    Rigidbody2D rb;

    private void Start() => rb = GetComponent<Rigidbody2D>();

    private void FixedUpdate()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Vector2.up, distance, layerMask);
        if(hitinfo.collider != null)
        {
            if (Input.GetKey(KeyCode.W)) climbing = true;
        }

        else climbing = false;

        if (climbing == true && hitinfo.collider != null)
        {
            InputVertical = Input.GetAxisRaw("Vertical");
            rb.position = new Vector2(rb.position.x, rb.position.y + InputVertical * speed);
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
        }

        else
            rb.gravityScale = 3;
    }
}
