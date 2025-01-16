using UnityEngine;

public class PlayerController: MonoBehaviour
{
    private Rigidbody2D rb;

    private float inputH;

    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float jumpPower;
    

    private bool isJumping = false;

    private float time;

    [SerializeField] private Animator animator;

    


    private bool isFacingRight = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputH =  Input.GetAxisRaw("Horizontal");
        FlipSprite();

        if(Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJumping = true;
            animator.SetBool("Grounded", false);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocityX = inputH * velocidadMovimiento;
        animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocityX));
        animator.SetFloat("Jump", rb.linearVelocityY);

        animator.SetBool("Grounded", !isJumping);
    }

    private void FlipSprite()
    {
        if (isFacingRight && inputH < 0f || !isFacingRight && inputH > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        

        }
    }

   


    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
        

        /*if (rb.linearVelocityY < 0f) rb.linearVelocityY = 0f;
        var dir = transform.position - collision.transform.position;
        transform.position += dir.normalized;
        */
    }
}
