using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class ChestS : MonoBehaviour
{
    public Character character;
    [SerializeField]
    private int hp = 1;
    [SerializeField]
    private int numOfRunesInside = 1;

    private void Update()
    {
        if (hp < 1)
        {
            GiveRunes();
            Destroy(gameObject);
        }
    }

    private void GiveRunes()
    {
        character.GetComponent<Character>().numOfRunes += numOfRunesInside;
    }
}
