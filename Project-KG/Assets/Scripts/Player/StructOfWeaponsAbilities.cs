using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructOfWeaponsAbilities : MonoBehaviour
{
    //name var, value, numOfRunes, ActivatedCheck
    public Tuple<string, float, int>[] MeleeAbilities =
    {
        Tuple.Create("meleeAttackDamageModification", 1.0f, 3),
        Tuple.Create("meleeAttackRadiusModification", 0.1f, 5)
    };

    public Tuple<string, float, int>[] RangeAbilities =
    {
        Tuple.Create("rangeAttackDamageModification", 3.0f, 3),
        Tuple.Create("rangeAttackCoolDownModification", 0.1f, 5)
    };
    private void Start()
    {

    }
}