﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRune : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = collider.GetComponent<Player>();
        if (player)
        {
            player.numWeaponsRunes++;
            Destroy(gameObject);
        }
    }
}
