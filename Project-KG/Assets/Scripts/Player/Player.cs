using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : DamageableObject
{
    public Animator animator;

    // public Rigidbody2D rb2d;

    private float _defaultMoveSpeed = 3.0f;
    private float _defaultJumpForce = 10.0f;
    private float _defaultDashForce = 10.0f;
    private float _defaultDashCoolDown = 2.0f;

    private float _defautMeleeAttackDamage = 4.0f;
    private float _defaultMeleeAttackRadius = 0.5f;
    private float _defaultMeleeAttackCoolDown = 0.0f;

    private float _defaultRangeAttackDamage = 20.0f;
    private float _defaultMoveSpeedBullet = 10.0f;
    private float _defaultRangeAttackCoolDown = 3.0f;

    private float _defaulSlamCoolDown = 6F;

// переменные, по которым обращаемся в других скриптах, равные defaut + modification 
    public float moveSpeed;
    public float jumpForce;
    public float dashForce;
    public float dashCoolDown;

    public float meleeAttackDamage;
    public float meleeAttackRadius;
    public float meleeAttackCoolDown;

    public float rangeAttackDamage;
    public float moveSpeedBullet;
    public float rangeAttackCoolDown;

    public float slamCoolDown;

    public float MaxHealthPoint = 100.0f;
    public int currNumCharacterRunes = 0; //текущее значение количества рун. Если добавляем руны персонажу, то используем это поле
    public int prevNumCharacterRunes = 0;
    public int valueCharacterRune = 3; //сколько хп добавляет одна руна
    public int numWeaponsRunes = 0;

    public Dictionary<int, int> learnedMeleeAbilities = new Dictionary<int, int>();
    public Dictionary<int, int> learnedRangeAbilities = new Dictionary<int, int>();
    // модификаторы наших переменных. Будут изменяться по мере улучшений персонажа или оружия 

    public float meleeAttackDamageModification { get; set; } = 0.0f;
    public float meleeAttackRadiusModification { get; set; } = 0.0f;
    public float meleeAttackCoolDownModification { get; set; } = 0.0f;

    public float rangeAttackDamageModification { get; set; } = 0.0f;
    public float rangeAttackCoolDownModification { get; set; } = 0.0f;

    public bool checkChangeRangeWeapon = false;
    public bool checkChangeMeleeWeapon = false;
    public float hp;

    public bool _isBlock = false;
    public bool _isSlowingTrap = false;

    public CharState State
    {

        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }

    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        Initialization();
    }

    private void Update()
    {
        
        ChangeParametresRangeWeapon();
        ChangeParametresMeleeWeapon();
        hp = _healthPoints;
        ChangeMaxHeathPoint();
    }
    

    private void Initialization()//приравниваем все публичные переменные начальным значениям
    {
        _healthPoints = MaxHealthPoint;
        // print("player hp = ");
        // print(_healthPoints);
        armor = 1;

        moveSpeed = _defaultMoveSpeed;
        jumpForce = _defaultJumpForce;
        dashForce = _defaultDashForce;
        dashCoolDown = _defaultDashCoolDown;

        meleeAttackDamage = _defautMeleeAttackDamage;
        meleeAttackRadius = _defaultMeleeAttackRadius;
        meleeAttackCoolDown = _defaultMeleeAttackCoolDown;

        rangeAttackDamage = _defaultRangeAttackDamage;
        moveSpeedBullet = _defaultMoveSpeedBullet;
        rangeAttackCoolDown = _defaultRangeAttackCoolDown;

        slamCoolDown = _defaulSlamCoolDown;

        numWeaponsRunes = 100;
        learnedMeleeAbilities.Add(-1,-1);
        learnedRangeAbilities.Add(-1, -1);
    }

    private void ChangeParametresRangeWeapon()
    {
        if(checkChangeRangeWeapon)
        {
            rangeAttackDamage += rangeAttackDamageModification;
            rangeAttackCoolDown += rangeAttackCoolDownModification;
            checkChangeRangeWeapon = false;
            // Debug.Log(rangeAttackDamage);
        }
    }
    private void ChangeParametresMeleeWeapon()
    {
        if (checkChangeMeleeWeapon)
        {
            meleeAttackDamage += meleeAttackDamageModification;
            meleeAttackRadius += meleeAttackRadiusModification;
            meleeAttackCoolDown += meleeAttackCoolDownModification;
            checkChangeMeleeWeapon = false;
            // Debug.Log(meleeAttackDamage);
        }


    }

    private void ChangeMaxHeathPoint()
    {
        if(currNumCharacterRunes != prevNumCharacterRunes)
        {
            MaxHealthPoint += (currNumCharacterRunes - prevNumCharacterRunes) * valueCharacterRune;
            prevNumCharacterRunes = currNumCharacterRunes;
        }
    }

    /*
    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {
        float timer = 0;

        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);

        while (knockDur > timer)
        {
            timer += Time.deltaTime;

            rb2d.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y + knockbackPwr, transform.position.z));
        }

        yield return 0;
    }
    */
}

public enum CharState
{
    Idle,
    Run,
    Jump,
    Dash,
    Melee_attack,
    Range_attack,
    Block,
    Slam
}