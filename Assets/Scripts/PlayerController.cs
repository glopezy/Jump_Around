
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bc;

    private float inputH;
    public float InputH { get => inputH; }

    [SerializeField] private bool crouching;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float jumpPower;

    [SerializeField] private Transform spawn;


    private bool isJumping = false;

    [SerializeField] private float hp;

    [SerializeField] private Animator animator;

    [SerializeField] private Transform detectCenter;
    [SerializeField] private float detectRadius;
    [SerializeField] private LayerMask isInteractable;

    [SerializeField] private CameraFollow camera;

    private bool isFacingRight = true;

    public bool IsFacingRight { get => isFacingRight; }
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
       

            if (hp <= 0)
        {
            Debug.Log("C murio");
            //FindAnyObjectByType<GameManager>().Restart();
        }
        
        inputH =  Input.GetAxisRaw("Horizontal");
        FlipSprite();

        //hold
        if(Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJumping = true;
            animator.SetBool("Grounded", false);
        }

        //release
        if (Input.GetButtonUp("Jump") && rb.linearVelocityY >= 0)
        {
            rb.linearVelocityY = 0;
        }

        if (Input.GetKeyDown(KeyCode.S) && !isJumping)
        {
            crouching = true;
            camera.IsCrouching = true;
            animator.SetBool("Crouching", true);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            crouching = false;
            camera.IsCrouching = false;
            animator.SetBool("Crouching", false);
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D collDetected = Physics2D.OverlapCircle(detectCenter.position, detectRadius, isInteractable);
            if (collDetected != null)
            {
                collDetected.GetComponent<Lever>().Activate();

            }

        }
    }

    private void FixedUpdate()
    {
        if (!crouching)
        {
            rb.linearVelocityX = inputH * velocidadMovimiento;
            animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocityX));
            animator.SetFloat("Jump", rb.linearVelocityY);

            animator.SetBool("Grounded", !isJumping);
        }

        
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


        foreach (ContactPoint2D contact in collision.contacts)
        {
            if(contact.normal.y > 0)
            {
                isJumping = false;
                //break;
            }
        }

        if (collision == null)
        {
            isJumping = true;
        }
        
        

        /*if (rb.linearVelocityY < 0f) rb.linearVelocityY = 0f;
        var dir = transform.position - collision.transform.position;
        transform.position += dir.normalized;
        */
    }

    public void Die()
    {
        
        bc.enabled = false;
        DieAnim();
    }

    private void DieAnim()
    {
       rb.AddForce(Vector2.up * jumpPower/2, ForceMode2D.Impulse);
    }
}
