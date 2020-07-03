using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowingTrap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = collider.GetComponent<Player>();
        if (player)
        {
            player._isSlowingTrap = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        Player player = collider.GetComponent<Player>();
        if (player)
        {
            player._isSlowingTrap = false;
        }
    }
}
