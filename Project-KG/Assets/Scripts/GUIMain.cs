using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIMain : MonoBehaviour
{
    public Character character;
    //public Slider HealthBar;
    public Text runes;
    public Image DashCD;
    public Image HealthBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //HealthBar.value = character.hero_hp;
        HealthBar.fillAmount = character.hero_hp / 20;
        runes.text = character.numOfRunes.ToString();
        DashCD.fillAmount = ((character.curTime - character.dashTime) / character.dashCoolDown);
    }
}
