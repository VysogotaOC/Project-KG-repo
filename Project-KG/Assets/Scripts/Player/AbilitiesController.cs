using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesController : MonoBehaviour
{
    public Player _player;
    private StructOfWeaponsAbilities _weaponsAbility;
    public bool activate = false;
    public int type_of_up;
    public int i;
    public Store store;

    void Start()
    {
        _weaponsAbility = GetComponent<StructOfWeaponsAbilities>();
    }

    // Update is called once per frame
    void Update()
    {
        Abilities();
    }
    private void Abilities()
    {
        if (activate == true) 
        {
            if (type_of_up == 0)
            {

                if (_player.numWeaponsRunes >= _weaponsAbility.MeleeAbilities[i].Item3)
                {
                    if (_player.learnedMeleeAbilities.ContainsKey(i))
                    {
                        print("Способность уже изучена");
                        activate = false;
                        store.flagEnabled = 1;
                        return;
                    }

                    if (_player.learnedMeleeAbilities.ContainsKey(i - 1))
                    {
                        store.flagEnabled = 0;
                        float buff = (float)Convert.ToDouble(_player.GetType().GetProperty(_weaponsAbility.MeleeAbilities[i].Item1).GetValue(_player));
                        //Debug.Log(buff);
                        buff += _weaponsAbility.MeleeAbilities[i].Item2;
                        _player.GetType().GetProperty(_weaponsAbility.MeleeAbilities[i].Item1).SetValue(_player, buff);
                        _player.learnedMeleeAbilities.Add(i, i);
                        _player.checkChangeMeleeWeapon = true;
                        _player.numWeaponsRunes -= _weaponsAbility.MeleeAbilities[i].Item3;
                        print(_player.numWeaponsRunes);
                        print("Способность добавлена");
                        activate = false;
                    }
                    activate = false;
                } 
                else store.flagEnabled = 2;
                activate = false;
               
            }
            
            if(type_of_up == 1)
            {
                //int i = 0;
                if (_player.numWeaponsRunes >= _weaponsAbility.RangeAbilities[i].Item3)
                {
                    if (_player.learnedRangeAbilities.ContainsKey(i))
                    {
                        print("Способность уже изучена");
                        activate = false;
                        store.flagEnabled = 1;
                        return;
                    }
                    if (_player.learnedRangeAbilities.ContainsKey(i - 1))
                    {
                        store.flagEnabled = 0;
                        float buff = (float)Convert.ToDouble(_player.GetType().GetProperty(_weaponsAbility.RangeAbilities[i].Item1).GetValue(_player));
                        //Debug.Log(buff);
                        buff += _weaponsAbility.RangeAbilities[i].Item2;
                        _player.GetType().GetProperty(_weaponsAbility.RangeAbilities[i].Item1).SetValue(_player, buff);
                        _player.learnedRangeAbilities.Add(i, i);
                        _player.checkChangeRangeWeapon = true;
                        _player.numWeaponsRunes -= _weaponsAbility.RangeAbilities[i].Item3;
                        print(_player.numWeaponsRunes);
                        print("Способность добавлена");
                        activate = false;
                    }
                    activate = false;
                }
                activate = false;
            }
            else store.flagEnabled = 2;
            activate = false;
            
        }
        activate = false;
        
    }
}
