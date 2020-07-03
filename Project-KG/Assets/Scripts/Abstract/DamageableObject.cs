using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableObject : MonoBehaviour
{
    [SerializeField] protected float _healthPoints;
    private Player _player;
    public float armor;

    private void Start()
    {
        _player = GetComponent<Player>();
    }
    public void ReceiveDamage(float damage)
    {
        _healthPoints -= damage ;

        if (_healthPoints <= 0)
        {
            Die();
        }
    }

    public void HealDamage(float amountOfHeal, float maxHP)
    {
        
        if ((maxHP - _healthPoints) < amountOfHeal)
        {
            _healthPoints = maxHP;
        } else
        {
            _healthPoints += amountOfHeal;
        }
        
        // Debug.Log(_player.MaxHealthPoint);
        // Debug.Log(maxHP);
        // _healthPoints += amountOfHeal;
    }

    private void Die()=>    Destroy(gameObject);
    
}
