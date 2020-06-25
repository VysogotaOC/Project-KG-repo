using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsters : Unit
{
    [SerializeField]
    private float speed = 1.5F;

    [SerializeField]
    private float aggroField = 4.0F;

    public Transform player;
    private SpriteRenderer sprite;


    private void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        // if monster got an aggro do "Run();" until reached attack range
        if (distToPlayer < aggroField && distToPlayer > 1)
            Run();
        else
        {
            // do attack
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
}
