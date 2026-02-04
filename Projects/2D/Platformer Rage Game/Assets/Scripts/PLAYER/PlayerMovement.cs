using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float horizontal;
    [SerializeField] public float speed;
    [SerializeField] public float jumpforce;
    [SerializeField] private bool isFacingRight = true;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animatorController;
    BackgroundMusic backgroundMusic;

    private bool isGroundedNow;

    void Awake()
    {
       backgroundMusic = GameObject.FindGameObjectWithTag("Audio").GetComponent<BackgroundMusic>();
    }
    void Start(){
        animatorController = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        // Only allow jumping if grounded
        if (Input.GetButtonDown("Jump") && isGroundedNow)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpforce);
            backgroundMusic.PlaySFX(backgroundMusic.jump);

        }

        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }

        Flip();
        bool isMoving = horizontal != 0;

        animatorController.SetBool("isWalking", isMoving);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
        isGroundedNow = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
