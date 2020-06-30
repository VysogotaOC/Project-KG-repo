using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackController : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask damageableLayerMask;

    public bool massAttack = false;

    private Player _player;
    private Animator _animator;
    private float _timer;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, _player.meleeAttackRadius);
    }

    private void Start()
    {
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
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
                Debug.Log(_player.meleeAttackDamage);
                Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPoint.position, _player.meleeAttackRadius, damageableLayerMask);

                if (!massAttack)
                {
                    GameObject obj = NearTarget(attackPoint.position, colliders);
                    if (obj != null && obj.GetComponent<Monsters>())
                    {
                        obj.GetComponent<DamageableObject>().ReceiveDamage(_player.meleeAttackDamage);
                    }
                    _timer = _player.meleeAttackCoolDown;
                    return;
                }

                foreach (Collider2D hit in colliders)
                {
                    if (hit.GetComponent<DamageableObject>())
                    {
                        hit.GetComponent<DamageableObject>().ReceiveDamage(_player.meleeAttackDamage);
                    }
                }
                _timer = _player.meleeAttackCoolDown;


            }
            
        }
        else { _timer -= Time.deltaTime; }
        
    }
}
