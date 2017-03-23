using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInitialisation : MonoBehaviour {

    public GameObject[] droneTab;
    public GameObject Shield;

    private BaseStats stats;
	// Use this for initialization
	void Awake () {
        stats = GameObject.Find("Stats").GetComponent<BaseStats>();

        //DroneInit
		for(int i =0; i <stats.NumberDroneStat;i++)
        {
            droneTab[i].SetActive(true);
            droneTab[i].GetComponentInChildren<DualBlastersScript>().damage = 1 + stats.fireDroneStat;
        }

        //Shield init
        Shield.GetComponent<Shield>().health = 50 + (stats.ShieldStat * 50);
        Shield.GetComponent<Shield>().shieldRechargeRate = 1 + (stats.RechargeStat * 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
