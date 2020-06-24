using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //[SerializeField]
   // private int lives = 5;
    [SerializeField]
    private float speed = 3.0F;
    [SerializeField]
    private float jumpForce = 15.0F;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public int dubleJump;

    private Animator animator;

    

    new private Rigidbody2D rigidbody;
    
    private SpriteRenderer sprite;
    private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void FixedUpdate()
    {        
        CheckGround();
    }
    private void Update()
    {
        if (isGrounded == true) dubleJump = 1;

        if (isGrounded) State = CharState.Idle;
        if (Input.GetButton("Horizontal")) Run();

        if (Input.GetKeyDown(KeyCode.UpArrow) && dubleJump > 0) Jump();
        
    }
    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        sprite.flipX = direction.x < 0.0F;

        if (isGrounded) State = CharState.Run;
    }
    private void Jump()
    {
        rigidbody.velocity = Vector2.up * jumpForce;
        dubleJump--;
    }
    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if (!isGrounded) State = CharState.Jump;
    }
}

public enum CharState
{
    Idle,
    Run,
    Jump
}