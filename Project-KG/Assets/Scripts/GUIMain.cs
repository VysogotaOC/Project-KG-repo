using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIMain : MonoBehaviour
{
    public Image HealCD;
    public SpaceAbilities spaceAbilities;
    public Player player;
    public Text runes;
    public Text HealthCurr;
    public Image DashCD;
    public Image SlamCD;
    public Image SpearCD;
    public Image HealthBar;
    public MoveController moveController;
    public RangeAttackController rangeController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // HealCD.fillAmount = ((Time.time - spaceAbilities.lastHealTime) / spaceAbilities.healCoolDown);
        HealthCurr.text = player.hp.ToString() + "/" + player.MaxHealthPoint.ToString();
        HealthBar.fillAmount = player.hp / player.MaxHealthPoint;
        runes.text = player.numWeaponsRunes.ToString();
        DashCD.fillAmount = ((moveController.curDashTime - moveController.dashTime) / player.dashCoolDown);
        SlamCD.fillAmount = ((moveController.curDashTime - moveController._curSlamTime) / player.slamCoolDown);
        //SpearCD.fillAmount = ((moveController.curDashTime - moveController.dashTime) / player.rangeAttackCoolDown);
        SpearCD.fillAmount = ((player.rangeAttackCoolDown - rangeController._timer) / player.rangeAttackCoolDown);
    }
}
