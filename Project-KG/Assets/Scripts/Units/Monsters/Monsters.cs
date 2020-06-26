using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Monsters : Unit
{
    private float timer;
    public float resetAttack;
    public Character character;

    [SerializeField]
    private float speed = 1.5F;
    [SerializeField]
    private float aggroField = 4.0F;
    [SerializeField]
    private bool isItHero = false;
    [SerializeField]
    private float attackRange = 1.2F;
    [SerializeField]
    private int monsterDamage = 5;

    public Transform player;
    private SpriteRenderer sprite;

    
    public float hp = 10;
    public bool flag = false;
    private void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        // if monster got an aggro do "Run();" until reached attack range
        if (distToPlayer < aggroField)
        {
            Aggro(distToPlayer);
        } 
        
        if (hp <= 0)
        {
            base.Die(isItHero);
        }
    }
    
    private void Aggro(float distToPlayer)
    {

        timer += Time.deltaTime;
        if (distToPlayer > attackRange)
            Run();
        if (distToPlayer <= attackRange)
        {
            if (timer > resetAttack + 2)
            {
                character.ReceiveDamage(monsterDamage);
                Debug.Log(character.hero_hp);


                timer = 0;
            }

        }
    }
    private void Run()
    {
        Vector3 direction = player.position - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        if (direction.x > 0)
            sprite.flipX = false;
        else sprite.flipX = true;
    }
    public override void ReceiveDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0) base.Die(isItHero);
    }
}
