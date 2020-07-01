using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableObject : MonoBehaviour
{
    [SerializeField] protected float _healthPoints;
    
    public float armor;

    public void ReceiveDamage(float damage)
    {
        _healthPoints -= damage ;

        if (_healthPoints <= 0)
        {
            Die();
        }

        print("Hit!");
    }

    private void Die()=>    Destroy(gameObject);
    
}
