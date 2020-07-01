using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIMain : MonoBehaviour
{
    public Player player;
    //public Slider HealthBar;
    public Text runes;
    public Image DashCD;
    public Image HealthBar;
    public MoveController moveController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //HealthBar.value = character.hero_hp;
        HealthBar.fillAmount = player.hp / 20;
        runes.text = player.numWeaponsRunes.ToString();
        DashCD.fillAmount = ((moveController.curDashTime - moveController.dashTime) / player.dashCoolDown);
    }
}
