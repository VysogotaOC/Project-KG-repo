using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRune : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = collider.GetComponent<Player>();
        if (player)
        {
            player.currNumCharacterRunes++;
            Destroy(gameObject);
        }
    }

}
