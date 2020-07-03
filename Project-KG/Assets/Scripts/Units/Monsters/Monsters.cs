using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monsters : DamageableObject
{
    public float resetAttack;
    public Player player;


    public Transform playerTransform;
    public GameObject HP_UI;

    public float MaxHP;
    public float hp;
    private void Start()
    {
        hp = MaxHP = _healthPoints = 20;
    }
    private void Update()
    {
        //Debug.Log("monter hp=");
        //Debug.Log(_healthPoints);
        hp = _healthPoints;
        HP_UI.transform.localScale = new Vector2(hp/MaxHP, 1);
    }
    
}
