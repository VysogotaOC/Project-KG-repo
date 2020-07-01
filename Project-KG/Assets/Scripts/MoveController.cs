using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MoveController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator _animator;//Интерфейс для контроля анимационной системы Mecanim.
    private SpriteRenderer _sprite;
    private float _curTime;
    private RaycastHit2D _checkGroundRay;
    private bool _isGround;
    

   // public Transform groundCheckPoint;
    public LayerMask groundLayerMask;
    public float moveSpeed = 3.0F;
    public float jumpForce = 10.0F;
    public float checkRadius = .3F;
    public float RayDistance;
    public float dashTime;
    public float dashCoolDown = 3f;
    public bool doubleJump;
    public bool faceRight = true;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        if (_isGround) doubleJump = true;
        _curTime = Time.time;
        if (Input.GetButton("Horizontal"))
            Run();
        if (Input.GetKeyDown(KeyCode.UpArrow)) Jump();
        if (Input.GetKeyDown(KeyCode.LeftShift))
            Dash();
    }

    

    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        if (!faceRight) direction = -direction;
        if(direction.x < 0.0f && faceRight)
        {
            Flip();
        }
        else if(direction.x > 0.0f && !faceRight)
        {
            Flip();
        }

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, moveSpeed * Time.deltaTime);

        //if (_isGrounded) State = CharState.Run;
    }
    private void Jump()
    {
        
        if (doubleJump)
        {
            //State = CharState.Jump;
            _rigidbody.velocity = Vector2.up * jumpForce;
            //_rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            doubleJump = false;
        }
    }

    private void Dash()
    {
        if (_curTime - dashTime >= dashCoolDown)
        {
            //State = CharState.Dash;           
            _rigidbody.AddForce(Vector2.right * jumpForce * (faceRight ? 1.0f : -1.0f), ForceMode2D.Impulse);   
           // _rigidbody.velocity = new Vector2((_faceRight ? 1.0f : -1.0f) * jumpForce, _rigidbody.velocity.y);
            dashTime = _curTime;
            

        }

    }

    private void CheckGround()
    {
        //if (!_isGrounded) State = CharState.Jump;
        _checkGroundRay = Physics2D.Raycast
            (
                transform.position,
                -Vector2.up,
                RayDistance,
                groundLayerMask
            );
        _isGround = _checkGroundRay;
    }


    private void Flip()
    {
        transform.Rotate(0.0f, 180.0f, 0.0f);
        faceRight = !faceRight;
    }

}

