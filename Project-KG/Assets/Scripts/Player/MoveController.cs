using System;
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
    private Player _player;
    public float curDashTime;
    private RaycastHit2D _checkGroundRay;
    private bool _isGround;
    public float _curSlamTime;

    // public Transform groundCheckPoint;
    public LayerMask groundLayerMask;
    public float RayDistance = 0.3f;
    public float dashTime;
    public float dashCoolDown = 3f;
    public bool doubleJump;
    public bool faceRight = true;
    public bool checkFall;
    


    private void Start()
    {
        _player = GetComponent<Player>();
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
        curDashTime = Time.time;
        if (Input.GetButton("Horizontal"))
            Run();
        if (Input.GetKeyDown(KeyCode.UpArrow)) Jump();
        if (Input.GetKeyDown(KeyCode.LeftShift)) Dash();
        if (Input.GetKeyDown(KeyCode.DownArrow)) Fall();
        if (Input.GetKey(KeyCode.D)) Block();
        if (Input.GetKeyUp(KeyCode.D)) Recovery();
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
        if (_player._isBlock || _player._isSlowingTrap)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, (_player.moveSpeed / 2)  * Time.deltaTime);
        }
        else  transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, _player.moveSpeed * Time.deltaTime);

        //if (_isGrounded) State = CharState.Run;
    }
    private void Jump()
    {
        
        if (doubleJump && !_player._isBlock)
        {
            //State = CharState.Jump;
            _rigidbody.velocity = Vector2.up * _player.jumpForce;
            doubleJump = false;
        }
    }

    private void Dash()
    {
        if (curDashTime - dashTime >= _player.dashCoolDown)
        {
            //State = CharState.Dash;           
            _rigidbody.AddForce(Vector2.right * _player.dashForce * (faceRight ? 1.0f : -1.0f), ForceMode2D.Impulse);   
         
            dashTime = curDashTime;
            

        }

    }

    private void Fall()
    {
        if (!_isGround)
        {
            _rigidbody.velocity = Vector2.down * _player.jumpForce * 2;
            checkFall = true;
            if (_player._isBlock == true && Time.time - _curSlamTime >= _player.slamCoolDown)
            {
                // Debug.Log(_player.meleeAttackDamage);
                //анимация
                 MeleeAttackController.Slam(transform.position, 1.5F, 9, _player.meleeAttackDamage * 2);
                _curSlamTime = Time.time;
            }
                
        }
    }

    private void CheckGround()
    {
        //if (!_isGround) State = CharState.Jump;
        _checkGroundRay = Physics2D.Raycast
            (
                transform.position,
                -Vector2.up,
                RayDistance,
                groundLayerMask
            );
        _isGround = _checkGroundRay;
        if (_isGround) checkFall = false;
    }


    private void Flip()
    {
        transform.Rotate(0.0f, 180.0f, 0.0f);
        faceRight = !faceRight;
    }

    private void Block()
    {
        _player._isBlock = true;
        _player.armor = 2;
    }

    private void Recovery()
    {
        _player._isBlock = false;
        _player.armor = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if(collision.gameObject.tag.Equals("MovingPlatform"))
        {
            this.transform.parent = collision.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("MovingPlatform"))
        {
            this.transform.parent = null;
        }
    }
}


