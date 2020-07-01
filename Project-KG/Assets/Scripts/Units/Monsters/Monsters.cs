using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monsters : DamageableObject
{
    private float timer;
    public float resetAttack;
    public Player player;

    [SerializeField]
    private float speed = 1.5F;
    [SerializeField]
    private float aggroField = 4.0F;
    [SerializeField]
    private bool isItHero = false;
    [SerializeField]
    private float attackRange = 1.2F;
    [SerializeField]
    private int monsterDamage = 5;

    public Transform playerTransform;
    private SpriteRenderer sprite;
    public GameObject HP_UI;

    public float MaxHP;
    public float hp;
    public bool flag = false;
    private void Start()
    {
        hp = MaxHP = _healthPoints = 20;
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void Update()
    {
        //Debug.Log("monter hp=");
        //Debug.Log(_healthPoints);
        hp = _healthPoints;
        HP_UI.transform.localScale = new Vector2(hp/MaxHP, 1);
        float distToPlayer = Vector2.Distance(transform.position, playerTransform.position);
        // if monster got an aggro do "Run();" until reached attack range
        if (distToPlayer < aggroField)
        {
            //Aggro(distToPlayer);
        } 
        
    }
    
    // Update is called once per frame
}
