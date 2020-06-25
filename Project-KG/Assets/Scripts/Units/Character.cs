using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Unit
{
    // [SerializeField]
    // private int lives = 5;
    [SerializeField]
    private float speed = 3.0F;
    [SerializeField]
    private float jumpForce = 15.0F;
    [SerializeField]
    private float dashTime;
    [SerializeField]
    private float dashCoolDown = 3F;


    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public int doubleJump;

    public Transform punch1;
    public float punch1Radius;

    private Bullet bullet;

    // private Animator animator;

    new private Rigidbody2D rigidbody;
    
    private SpriteRenderer sprite;
   /* private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }*/

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        bullet = Resources.Load<Bullet>("Bullet");
    }
    private void FixedUpdate()
    {   
        CheckGround();
    }
    private void Update()
    {
        dashTime += Time.deltaTime;
        if (isGrounded == true) doubleJump = 1;
 
        if (isGrounded) State = CharState.Idle;
        if (Input.GetButtonDown("Fire1")) Shoot();
        if (Input.GetButton("Horizontal")) Run();

        if (Input.GetKeyDown(KeyCode.UpArrow) && doubleJump > 0) Jump();
        if (Input.GetKeyDown(KeyCode.LeftShift)) Dash();
         

        if (Input.GetKeyDown(KeyCode.LeftShift))Dash();
        if (Input.GetKeyDown(KeyCode.Space)) MelleAttack.Action(punch1.position, punch1Radius, 9, 12, false);//координата точки нанесения урона, радиус действия урона, какому слою объектовв наносим урон, количество урона, массовый ли урон
        

    }
    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        sprite.flipX = direction.x < 0.0F;

        //if (isGrounded) State = CharState.Run;
    }
    private void Jump()
    {
        rigidbody.velocity = Vector2.up * jumpForce;
        doubleJump--;
    }

    private void Dash()
    {
        if(dashTime >= dashCoolDown) {
            Vector3 direction = transform.right;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction* (sprite.flipX ? -1.0F : 1.0F), jumpForce);
            /*if (sprite.flipX) { rigidbody.velocity = Vector2.left * jumpForce; }
        else { rigidbody.velocity = Vector2.right * jumpForce * 0.8F;}*/
        
        dashTime = 0;
        }
        
    }

    private void Shoot()
    {
        Vector3 position = transform.position; position.y += 0.8F;
        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation);

        newBullet.Parent = gameObject;
        newBullet.Direction = newBullet.transform.right * (sprite.flipX ? -1.0F : 1.0F);
    }

    private void CheckGround()
    {
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        //if (!isGrounded) State = CharState.Jump;
    }

    // public Transform MyTarget { get; get; }
}

public enum CharState
{
    Idle,
    Run,
    Jump
}