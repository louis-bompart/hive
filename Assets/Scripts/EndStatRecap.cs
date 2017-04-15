using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndStatRecap : MonoBehaviour {

    public Text UpgradeRecapShip;
    public Text UpgradeRecapBase;
    public Text QuestCompletedRecap;
    public Text AsteroidsDestroyedRecap;
    public Text EnemiesDestroyedRecap;
    public Text ItemsCraftedRecap;

	// Use this for initialization
	void Start () {
        ShipStats shipstats = GameObject.Find("Data").GetComponentInChildren<ShipStats>();
        BaseStats basestats = GameObject.Find("Data").GetComponentInChildren<BaseStats>();
        OtherStats otherstats = GameObject.Find("Data").GetComponentInChildren<OtherStats>();
        QuestProgress questprogress = GameObject.Find("Data").GetComponentInChildren<QuestProgress>();
        int upgradeshipcount = shipstats.healthStat + shipstats.armorStat + shipstats.damageStat + shipstats.fireRateStat + shipstats.topSpeed + shipstats.handlingStat;
        UpgradeRecapShip.text = "Ship upgrades : " + upgradeshipcount.ToString();
        int upgradebasecount = basestats.chargeStat + basestats.fireDroneStat + basestats.numberDronesStat + basestats.printerStat + basestats.scanRangeStat + basestats.shieldStat;
        UpgradeRecapBase.text = "Base upgrades : " + upgradebasecount.ToString();
        QuestCompletedRecap.text = "Numer of completed quests : " + questprogress.CompletedQuests.Count.ToString();
        AsteroidsDestroyedRecap.text = "Asteroids mined : " + otherstats.DestroyedAsteroids.ToString();
        EnemiesDestroyedRecap.text = "Enemies destroyed : " + otherstats.DestroyedEnemies.ToString();
        ItemsCraftedRecap.text = "Items crafted : " + otherstats.CraftedItems.ToString();
    }
	
}
