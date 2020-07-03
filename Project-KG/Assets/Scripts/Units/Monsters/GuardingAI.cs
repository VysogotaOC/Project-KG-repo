using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardingAI : MonoBehaviour
{

    // public Character character;

    [SerializeField]
    private float speed = 1.5F;
    [SerializeField]
    private float startAggroZone = 2.0F;
    [SerializeField]
    private float finishAggroZone = 2.0F;


    private SpriteRenderer mobSprite;
    private GameObject player;

    private Vector3 defaultPosition;



    void Start()
    {
        mobSprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        
        // Vector3 defaultPosition = transform.position;

        defaultPosition = transform.position;
        startAggroZone = transform.position.x + startAggroZone;
        finishAggroZone = transform.position.x + finishAggroZone;
    }


    private void Update()
    {
        // Debug.Log(player.transform.position.x);
        // float distToPlayer = Vector2.Distance(transform.position, player.transform.position);
        // if monster got an aggro do "Run();" until reached attack range
        if (player.transform.position.x > startAggroZone && player.transform.position.x < finishAggroZone)
        {

            Run();
        }
        else
        {
            if (transform.position != defaultPosition)
            {
                BaseRun();
            }
        }
        
    }

    private void Run()
    {
        // Debug.Log(transform.position);
        Vector3 direction = player.transform.position - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        
        if (direction.x > 0)
            mobSprite.flipX = false;
        else mobSprite.flipX = true;
    }

    private void BaseRun()
    {
        Vector3 direction = defaultPosition - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        
        if (direction.x > 0)
            mobSprite.flipX = false;
        else mobSprite.flipX = true;
    }
}
