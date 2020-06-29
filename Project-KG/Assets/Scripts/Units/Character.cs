﻿using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Unit
{
    //times
    private float curTime;
    [SerializeField]
    public float dashTime = 0.0F;
    [SerializeField]
    public float shootTime = 0.0F;
    [SerializeField]
    private float dashCoolDown = 3F;
    [SerializeField]
    private float shootCoolDown = 3F;
    [SerializeField]
    public int hero_hp = 20;
    [SerializeField]
    public float speed = 4.0F;
    [SerializeField]
    private float jumpForce = 15.0F;
    [SerializeField]
    private bool isItHero = true;

    
    public int numOfRunes = 0;



    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public int doubleJump;

    public Transform punch1;
    public float punch1Radius = 0.3F;

    private Bullet bullet;

    private Animator animator;

    new public Rigidbody2D rigidbody;
    
    private SpriteRenderer sprite;
   private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    private void Awake()
    {
        punch1 = GetComponent<Transform>();
        //rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        bullet = Resources.Load<Bullet>("Bullet");
    }
    private void FixedUpdate()
    {   
        CheckGround();
    }
    private void Update()
    {
        curTime += Time.deltaTime;
        if (isGrounded == true) 
            doubleJump = 1; 
        if (isGrounded) 
            State = CharState.Idle;        
        if (Input.GetButton("Horizontal")) 
            Run();

        if (Input.GetKeyDown(KeyCode.UpArrow) && doubleJump > 0) 
            Jump();
        if (Input.GetKeyDown(KeyCode.LeftShift)) 
            Dash();
        
        if (Input.GetKeyDown(KeyCode.S)) 
            Shoot();
        if (Input.GetKeyDown(KeyCode.A))
        {
            State = CharState.Melee_attack;
            MelleAttack.Action(punch1.transform.position, punch1Radius, 9, 12.0F, false);
            // координата точки нанесения урона, радиус действия урона, какому слою объектовв наносим урон, количество урона, массовый ли урон
        }
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
        State = CharState.Jump;
        
        rigidbody.velocity = Vector2.up * jumpForce;
        doubleJump--;
    }

    private void Dash()
    {
        //float curT = Time.time;
        
         if(curTime - dashTime >= dashCoolDown)
         {
            State = CharState.Dash;
            Vector3 direction = transform.right;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction* (sprite.flipX ? -1.0F : 1.0F), jumpForce);
            dashTime = curTime;
            
         }
        
    }

    private void Shoot()
    {
        //float curTime = Time.time;
        if(curTime - shootTime >= shootCoolDown) 
        {
            State = CharState.Range_attack;
            Vector3 position = transform.position; position.y -= 0.2F;
            Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;
            newBullet.Parent = gameObject;
            newBullet.Direction = newBullet.transform.right * (sprite.flipX ? -1.0F : 1.0F);
            shootTime = curTime;
            
        }
    }

    private void CheckGround()
    {
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if (!isGrounded) State = CharState.Jump;
    }


    // public Transform MyTarget { get; get; }

    public void ReceiveDamage(int damage)
    {
        hero_hp -= damage;
        if(hero_hp <= 0) 
        {
            base.Die(isItHero);
        }
    }
}


public enum CharState
{
    Idle,
    Run,
    Jump,
    Dash,
    Melee_attack,
    Range_attack
}