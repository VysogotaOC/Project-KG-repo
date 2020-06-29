using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackController : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask damageableLayerMask;
    public float damage;
    public float attackRange;
    public float timeBtwAttack;
    public bool massAttack = false;

    private Animator _animator;
    private float _timer;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
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
                //_animator.SetTrigger("Attack");
                Debug.Log(damage);
                Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, damageableLayerMask);

                if (!massAttack)
                {
                    GameObject obj = NearTarget(attackPoint.position, colliders);
                    if (obj != null && obj.GetComponent<Monsters>())
                    {
                        obj.GetComponent<DamageableObject>().ReceiveDamage(damage);
                    }
                    _timer = timeBtwAttack;
                    return;
                }

                foreach (Collider2D hit in colliders)
                {
                    if (hit.GetComponent<DamageableObject>())
                    {
                        hit.GetComponent<DamageableObject>().ReceiveDamage(damage);
                    }
                }
                _timer = timeBtwAttack;


            }
            
        }
        else { _timer -= Time.deltaTime; }
        
    }
}
