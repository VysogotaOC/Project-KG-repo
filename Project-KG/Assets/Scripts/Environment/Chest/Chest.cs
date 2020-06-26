﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Chest : Monsters
{
    public Character character;
    //[SerializeField]
    //private new float hp = 1.0F;
    [SerializeField]
    private int numOfRunesInside = 10;


    public override void ReceiveDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            GiveRunes();
            base.Die();
        }
    }
    private void GiveRunes()
    {
        character.GetComponent<Character>().numOfRunes += numOfRunesInside;
    }
}
