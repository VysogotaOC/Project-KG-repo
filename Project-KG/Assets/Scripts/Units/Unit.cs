using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Unit : MonoBehaviour
{
    public virtual void ReceiveDamage(float damage)
    {
        
    }

    public virtual void Die(bool isItHero)
    {
        
        if(isItHero == true)
            SceneManager.LoadScene("SampleScene");
        else Destroy(gameObject);
    }
}
