using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toslow : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Character character = collider.GetComponent<Character>();
        if (character)
        {
            character.speed -= 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        Character character = collider.GetComponent<Character>();
        if (character)
        {
            character.speed += 1;
        }
    }
}
