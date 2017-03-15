using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStats : MonoBehaviour {

    public int HealthStat;
    public int ArmorStat;
    public int DamageStat;
    public int FireRateStat;
    public int TopSpeedStat;
    public int HandlingStat;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
