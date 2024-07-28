using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Animator animator;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheckPosition;
    [SerializeField] AudioClip[] sounds;

    private AudioSource source => GetComponent<AudioSource>();

    private float inputH;

    private bool isGrounded = false;
    private bool jumped;

    private Rigidbody2D body;

    private void Start() => body = GetComponent<Rigidbody2D>();

    private void FixedUpdate() => Move();

    private void Update()
    {
        CheckGround();
        Jump();
        SoundPlayer();

        if (Input.GetKey(KeyCode.LeftShift)) speed = 10f;
        else speed = 5f;

        animator.SetFloat("horizontalMove", Mathf.Abs(inputH));
    }

    private void Move()
    {
        inputH = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(speed * inputH, body.velocity.y);

        if (inputH > 0) ChangeDirection(8.233374f);
        if (inputH < 0) ChangeDirection(-8.233374f);
    }

    private void SoundPlayer()
    {
        if(jumped) 
            source.clip = null;
        else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) 
            && Input.GetKey(KeyCode.LeftShift)) 
            PlaySound(sounds[1], true);
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) 
            PlaySound(sounds[0], true);
        else
            source.clip = null;
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.Raycast(groundCheckPosition.position, Vector2.down, 0.1f, groundLayer);

        if (isGrounded)
        {
            if (jumped)
                jumped = false;
        }

    }

    private void Jump()
    {
        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                jumped = true;
                body.velocity = new Vector2(body.velocity.x, jumpForce);

                if (jumped == true)
                    animator.SetBool("jumping", true);
            }

            else
                animator.SetBool("jumping", false);
        }
    }

    private void ChangeDirection(float direction)
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = direction;
        transform.localScale = tempScale;
    }

    public void PlaySound(AudioClip clip, float volume = 1f, bool destroyed = false, float p1 = 1f)
    {
        source.pitch = p1; 
        source.PlayOneShot(clip, volume);
    }

    public void PlaySound(AudioClip clip, bool isLoop)
    {
        if (source.clip == clip) return;

        source.clip = clip;
        source.loop = isLoop;
        source.Play();
    }
}
