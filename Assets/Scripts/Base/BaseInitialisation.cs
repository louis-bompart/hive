using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInitialisation : MonoBehaviour {

    public GameObject[] droneTab;
    public GameObject shield;

    private BaseStats stats;
	// Use this for initialization
	void Awake () {
        stats = GameObject.Find("Stats").GetComponent<BaseStats>();

        //DroneInit
		for(int i =0; i <stats.numberDronesStat;i++)
        {
            droneTab[i].SetActive(true);
            droneTab[i].GetComponentInChildren<DualBlastersScript>().damage = 1 + stats.fireDroneStat;
        }

        //Shield init
        shield.GetComponent<Shield>().maxHP = 50 + (stats.shieldStat * 50);
        shield.GetComponent<Shield>().health = 50 + (stats.shieldStat * 50);
        shield.GetComponent<Shield>().shieldRechargeRate = 1 + (stats.chargeStat * 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
