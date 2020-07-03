using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monsters : DamageableObject
{
    public GameObject HP_UI;
    protected float MaxHP;
    



    protected void HPBar()
    {
        HP_UI.transform.localScale = new Vector2(_healthPoints / MaxHP, 1);
    }
}
