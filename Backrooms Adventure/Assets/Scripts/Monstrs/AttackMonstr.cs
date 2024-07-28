using UnityEngine;

public class AttackMonstr : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform player;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float stoppingDistance = 7f;
    [SerializeField] private float speed;
    [SerializeField] private float startWaitTime;

    private float waitTime;
    private int randomSpot;

    public Transform[] moveToPoint;

    public AudioClip[] sounds;
    private AudioSource source => GetComponent<AudioSource>();

    private Rigidbody2D rb;

    private bool isAttacking;
    private bool isFacingRight = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveToPoint.Length);
    }

    private void Update()
    {
        if (isAttacking && player != null)
        {
            if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                if (transform.position.x < player.position.x && isFacingRight) Flip();

                else if (transform.position.x > player.position.x && !isFacingRight) Flip();

                transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, moveToPoint[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveToPoint[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveToPoint.Length);
                waitTime = startWaitTime;
                animator.SetBool("view", true);
            }

            else waitTime -= Time.deltaTime;

            if ((transform.position.x < moveToPoint[randomSpot].position.x && isFacingRight) ||
                (transform.position.x > moveToPoint[randomSpot].position.x && !isFacingRight))
                Flip();
        }
    }

    public void AttackOn()
    {
        isAttacking = true;
        animator.SetBool("view", true);
        PlaySound(sounds[0]);
    }

    public void AttackFalse()
    {
        isAttacking = false;
        source.Stop();
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void PlaySound(AudioClip clip, float volume = 1f, bool destroyed = false, float p1 = 1f)
    {
        source.pitch = p1;
        source.PlayOneShot(clip, volume);
    }
}
