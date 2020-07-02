using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public Button[] melee_buttons;
    public Button[] range_buttons;
    public Text[] melee_texts;
    public Text[] range_texts;
    public Text DescriptionHead;
    public Text Description;
    public Text status;
    public int flagEnabled; //0 - добавлена, 1 - уже изучена, 2 - не хватает рун
    private StructOfWeaponsAbilities weaponsAbilities;
    private AbilitiesController abilities;
    private int i;
    private int type_of_up;  //0 - melee, 1 - range

    private void Start()
    {
        status.text = "";
        weaponsAbilities = GetComponent<StructOfWeaponsAbilities>();
        abilities = GetComponent<AbilitiesController>();
    }

    public void Get_Index(int index)
    {
        i = index;
        abilities.i = index;
    }

    public void Get_Type_of_Up(int index)
    {
        type_of_up = index;
        abilities.type_of_up = index;
    }

    public void Activate()
    {
        abilities.activate = true;
        /*if (flagEnabled == 0)
        {
            //status.SetActive(true);
            status.text = "Способность добавлена";
        }
        else if (flagEnabled == 1)
        {
            //status.SetActive(true);
            status.text = "Уже изучена";
        }
        else if (flagEnabled == 2)
        {
            //status.SetActive(true);
            status.text = "Не хватает рун";
        }*/
    }

    public void Skill_Description()
    {
        status.text = "";
        if (type_of_up == 0) 
        { 
            DescriptionHead.text = melee_texts[i].text;
            Description.text = weaponsAbilities.MeleeAbilities[i].Item1 + "\n" + "+" + weaponsAbilities.MeleeAbilities[i].Item2.ToString() + "\n" + "Стоимость " + weaponsAbilities.MeleeAbilities[i].Item3;
        } 
        else if (type_of_up == 1)
        {
            DescriptionHead.text = range_texts[i].text;
            Description.text = weaponsAbilities.RangeAbilities[i].Item1 + "\n" + "+" + weaponsAbilities.RangeAbilities[i].Item2.ToString() + "\n" + "Стоимость " + weaponsAbilities.RangeAbilities[i].Item3; ;
        }

    }
}
