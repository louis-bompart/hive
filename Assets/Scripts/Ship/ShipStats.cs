using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStats : MonoBehaviour
{
    public int healthStat;
    public int armorStat;
    public int damageStat;
    public int fireRateStat;
    public int topSppedStat;
    public int handlingStat;

    void Awake()
    {
        if (!AlreadyPresent())
        {
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    private bool AlreadyPresent()
    {
        ShipStats[] Ts = FindObjectsOfType<ShipStats>();
        return Ts.Length > 1;
    }
}
