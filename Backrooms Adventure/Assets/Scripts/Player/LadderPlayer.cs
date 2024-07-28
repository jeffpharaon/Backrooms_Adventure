using UnityEngine;

public class LadderPlayer : MonoBehaviour
{
    private Rigidbody2D rb;

    public void MoveToPosition()
    {
        Vector3 targetPosition = transform.position;
        rb.velocity = new Vector3(115.75f, 6.8f, 0);
    }
}
