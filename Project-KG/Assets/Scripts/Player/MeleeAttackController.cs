using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackController : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask damageableLayerMask;
    public float attackRange;
    public bool massAttack = false;

    private Player _player;
    private Animator _animator;
    private float _timer;
    public static float curSlamTime;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private void Start()
    {
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
        curSlamTime = 0;
    }
    private void Update()
    {
        Attack();
    }
    private GameObject NearTarget(Vector3 position, Collider2D[] array)
    {
        Collider2D current = null;
        float dist = Mathf.Infinity;

        foreach (Collider2D coll in array)
        {
            float curDist = Vector3.Distance(position, coll.transform.position);
            if (curDist < dist)
            {
                current = coll;
                dist = curDist;
            }
        }

        return (current != null) ? current.gameObject : null;
    }

    public void Attack()
    {
        if(_timer <= 0)
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
                attackRange = _player.meleeAttackRadius;
                //_animator.SetTrigger("Attack");
                // Debug.Log(_player.meleeAttackDamage);
                Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, damageableLayerMask);

                if (!massAttack)
                {
                    GameObject obj = NearTarget(attackPoint.position, colliders);
                    if (obj != null && obj.GetComponent<Monsters>())
                    {
                        obj.GetComponent<Monsters>().ReceiveDamage(_player.meleeAttackDamage);
                    }
                    _timer = _player.meleeAttackCoolDown;
                    return;
                }

                foreach (Collider2D hit in colliders)
                {
                    if (hit.GetComponent<Monsters>())
                    {
                        hit.gameObject.GetComponent<Monsters>().ReceiveDamage(_player.meleeAttackDamage);
                    }
                }
                _timer = _player.meleeAttackCoolDown;


            }
            
        }
        else { _timer -= Time.deltaTime; }
        
    }
    public static void Slam(Vector2 point, float radius, int monstersLayerMask, float damage)
    {
        // Debug.Log("damage");
        // Debug.Log(damage);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(point, radius, 1 << monstersLayerMask);
        // Debug.Log(colliders.Length);
        foreach (Collider2D hit in colliders)
        {
            GameObject b = hit.gameObject;
            // Debug.Log("hitSlam");
            Debug.Log(hit.gameObject);
            if (b.GetComponent<Monsters>())
            {
                
                b.GetComponent<Monsters>().ReceiveDamage(damage);
            }
        }
    }


}
