using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStats : MonoBehaviour {

    public int ScanRangeStat;
    public int printerStat;
    public int NumberDroneStat;
    public int fireDroneStat;
    public int ShieldStat;
    public int RechargeStat;


	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	

}
