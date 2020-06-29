using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Chest : Monsters
{
    
    //[SerializeField]
    //private new float hp = 1.0F;
    [SerializeField]
    private int numOfRunesInside = 10;


    public override void ReceiveDamage(float damage)
    {

        GiveRunes();
        Destroy(gameObject);
        
    }
    private void GiveRunes()
    {
        
    }
}
