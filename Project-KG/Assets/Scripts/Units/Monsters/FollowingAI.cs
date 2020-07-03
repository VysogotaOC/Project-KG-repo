using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingAI : MonoBehaviour
{
    // private Player _player;
    private Bullet _bullet;
    // private MoveController _move; Needed for block

    // public Character character;
    public Transform attackPoint;
    public LayerMask damageableLayerMask;



    [SerializeField]
    private float startAggroZone = 2.0F;
    [SerializeField]
    private float finishAggroZone = 2.0F;
    [SerializeField]
    private float speed = 1.5F;
    [SerializeField]
    private float aggroField = 4.0F;
    [SerializeField]
    private float attackRange = 1.2F;
    [SerializeField]
    private float meleeAttackDamage = 5.0F;
    [SerializeField]
    private float meleeAttackCoolDown = 2.0F;
    [SerializeField]
    private float rangeAttackCoolDown = 2.0F;
    [SerializeField]
    private bool isItMelee;

    private SpriteRenderer mobSprite;
    private GameObject player;
    
    private Vector3 defaultPosition;
    private float _timer;


    void Start()
    {
        mobSprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        _bullet = Resources.Load<Bullet>("Bullet");
        // _move = GetComponent<MoveController>(); Needed for block
        // _player = GetComponent<Player>();
        // Vector3 defaultPosition = transform.position;
        defaultPosition = transform.position;

        startAggroZone = transform.position.x + startAggroZone;
        finishAggroZone = transform.position.x + finishAggroZone;

    }


    private void Update()
    {
        // Debug.Log(defaultPosition);
        float distToPlayer = Vector2.Distance(transform.position, player.transform.position);
        // if monster got an aggro do "Run();" until reached attack range
        if (distToPlayer <= aggroField || (player.transform.position.x > startAggroZone && player.transform.position.x < finishAggroZone))
        {
            if(distToPlayer > attackRange)
            {
                Run();
            } 
            else
            {
                if (isItMelee)
                    MeleeAttack();
                else
                    RangeAttack();
                
            }
            
        } else if(transform.position != defaultPosition)
        {
            BaseRun();
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

    
    public void MeleeAttack()
    {
        if (_timer <= 0)
        {
            if (player.GetComponent<Player>())
            {
                // Debug.Log("got hit");

                player.GetComponent<Player>().ReceiveDamage(meleeAttackDamage);
            }
            _timer = meleeAttackCoolDown;
        }
        else { _timer -= Time.deltaTime; }

    }

    private void RangeAttack()
    {
        //float curTime = Time.time;
        if (_timer <= 0)
        {

            //State = CharState.Range_attack;
            Vector3 position = transform.position; position.y += 0.8F;   
            Bullet newBullet = Instantiate(_bullet, position, _bullet.transform.rotation) as Bullet;
            newBullet.Parent = gameObject;

            
            float directionForAttack = player.transform.position.x - transform.position.x;
            newBullet.Direction = newBullet.transform.right * directionForAttack;
            // (_move.faceRight ? 1.0f : -1.0f);
            _timer = rangeAttackCoolDown;
            
        }
        else { _timer -= Time.deltaTime; }
    }
}
