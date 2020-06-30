using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : DamageableObject
{
    private float _defaultMoveSpeed = 3.0f;
    private float _defaultJumpForce = 10.0f;
    private float _defaultDashForce = 10.0f;
    private float _defaultDashCoolDown = 2.0f;

    private float _defautMeleeAttackDamage = 4.0f;
    private float _defaultMeleeAttackRadius = 0.5f;
    private float _defaultMeleeAttackCoolDown = 0.0f;

    private float _defaultRangeAttackDamage = 6.0f;
    private float _defaultMoveSpeedBullet = 10.0f;
    private float _defaultRangeAttackCoolDown = 3.0f;

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

    public float MaxHealthPoint = 100.0f;
    public int currNumCharacterRunes = 0; //текущее значение количества рун. Если добавляем руны персонажу, то используем это поле
    public int prevNumCharacterRunes = 0;
    public int valueCharacterRune = 3; //сколько хп добавляет одна руна
    public int numWeaponsRunes = 100;

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

    private void Start()
    {
        Initialization();
    }

    private void Update()
    {
        ChangeParametresRangeWeapon();
        ChangeParametresMeleeWeapon();
    }

    private void Initialization()//приравниваем все публичные переменные начальным значениям
    {
        _healthPoints = MaxHealthPoint;
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
}
