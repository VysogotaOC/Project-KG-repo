using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class AbilitiesController : MonoBehaviour
{
    private Player _player;
    private StructOfWeaponsAbilities _weaponsAbility;
    void Start()
    {
        _player = GetComponent<Player>();
        _weaponsAbility = GetComponent<StructOfWeaponsAbilities>();
    }
    
    private void Update()
    {

    }
    private void Abilities()
    {
         //понять как из интерфейса передавать значение сюда
        if(Input.GetKeyDown(KeyCode.M))
        {
            //if("Если нажали на улучшение ближнего боя")
            //{
                int i = 0;
                if (_player.numWeaponsRunes >= _weaponsAbility.MeleeAbilities[i].Item3)
                {
                    if (_player.learnedMeleeAbilities.ContainsKey(i))
                    {
                        print("Способность уже изучена");
                        return;
                    }
                    if (_player.learnedMeleeAbilities.ContainsKey(i - 1))
                    {
                        float buff = (float)Convert.ToDouble(_player.GetType().GetProperty(_weaponsAbility.MeleeAbilities[i].Item1).GetValue(_player));
                        //Debug.Log(buff);
                        buff += _weaponsAbility.MeleeAbilities[i].Item2;
                        _player.GetType().GetProperty(_weaponsAbility.MeleeAbilities[i].Item1).SetValue(_player, buff);
                        _player.learnedMeleeAbilities.Add(i, i);
                        _player.checkChangeMeleeWeapon = true;
                        _player.numWeaponsRunes -= _weaponsAbility.MeleeAbilities[i].Item3;
                        print(_player.numWeaponsRunes);
                        print("Способность добавлена");
                    }
                }
            //}
            //if("Если нажали на улучшение дальнего боя")
            //{
                //int i = 0;
                if (_player.numWeaponsRunes >= _weaponsAbility.RangeAbilities[i].Item3)
                {
                    if (_player.learnedRangeAbilities.ContainsKey(i))
                    {
                        print("Способность уже изучена");
                        return;
                    }
                    if (_player.learnedRangeAbilities.ContainsKey(i - 1))
                    {
                        float buff = (float)Convert.ToDouble(_player.GetType().GetProperty(_weaponsAbility.RangeAbilities[i].Item1).GetValue(_player));
                        //Debug.Log(buff);
                        buff += _weaponsAbility.RangeAbilities[i].Item2;
                        _player.GetType().GetProperty(_weaponsAbility.RangeAbilities[i].Item1).SetValue(_player, buff);
                        _player.learnedRangeAbilities.Add(i, i);
                        _player.checkChangeRangeWeapon = true;
                        _player.numWeaponsRunes -= _weaponsAbility.RangeAbilities[i].Item3;
                        print(_player.numWeaponsRunes);
                        print("Способность добавлена");
                    }
                }
            //}
            
        }
        
    }
}
