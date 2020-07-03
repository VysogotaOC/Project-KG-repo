using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll : Monsters
{
    public float hp = 20.0F;
    void Start()
    {
        MaxHP = _healthPoints = hp;
    }


    void Update()
    {
        HPBar();
    }
}
