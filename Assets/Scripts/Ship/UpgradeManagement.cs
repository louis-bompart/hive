using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManagement : MonoBehaviour
{
    #region Gauge preparation
    private List<GameObject> HealthGaugeGrads = new List<GameObject>();
    private List<GameObject> ArmorGaugeGrads = new List<GameObject>();
    private List<GameObject> DamageGaugeGrads = new List<GameObject>();
    private List<GameObject> FireRateGaugeGrads = new List<GameObject>();
    private List<GameObject> TopSpeedGaugeGrads = new List<GameObject>();
    private List<GameObject> HandlingGaugeGrads = new List<GameObject>();
    private ShipStats stats;
    #endregion

    public void Start()
    {
        #region Gauge init
        GameObject HealthGauge = GameObject.Find("HealthUpgradeGauge");
        GameObject ArmorGauge = GameObject.Find("ArmorUpgradeGauge");
        GameObject DamageGauge = GameObject.Find("DamageUpgradeGauge");
        GameObject FireRateGauge = GameObject.Find("FireRateUpgradeGauge");
        GameObject TopSpeedGauge = GameObject.Find("TopSpeedUpgradeGauge");
        GameObject HandlingGauge = GameObject.Find("HandlingUpgradeGauge");
        stats = GameObject.Find("Stats").GetComponent<ShipStats>();
        foreach (Transform child in HealthGauge.transform)
        {
            HealthGaugeGrads.Add(child.gameObject);
        }
        foreach (Transform child in ArmorGauge.transform)
        {
            ArmorGaugeGrads.Add(child.gameObject);
        }
        foreach (Transform child in DamageGauge.transform)
        {
            DamageGaugeGrads.Add(child.gameObject);
        }
        foreach (Transform child in FireRateGauge.transform)
        {
            FireRateGaugeGrads.Add(child.gameObject);
        }
        foreach (Transform child in TopSpeedGauge.transform)
        {
            TopSpeedGaugeGrads.Add(child.gameObject);
        }
        foreach (Transform child in HandlingGauge.transform)
        {
            HandlingGaugeGrads.Add(child.gameObject);
        }

        int i = 0;
        foreach (GameObject grad in HealthGaugeGrads)
        {
            if (i < stats.HealthStat)
            {
                grad.GetComponent<RawImage>().color = Color.green;
                i++;
            }
            else
            {
                i = 0;
                break;
            }
        }
        foreach (GameObject grad in ArmorGaugeGrads)
        {
            if (i < stats.ArmorStat)
            {
                grad.GetComponent<RawImage>().color = Color.green;
                i++;
            }
            else
            {
                i = 0;
                break;
            }
        }
        foreach (GameObject grad in DamageGaugeGrads)
        {
            if (i < stats.DamageStat)
            {
                grad.GetComponent<RawImage>().color = Color.green;
                i++;
            }
            else
            {
                i = 0;
                break;
            }
        }
        foreach (GameObject grad in FireRateGaugeGrads)
        {
            if (i < stats.FireRateStat)
            {
                grad.GetComponent<RawImage>().color = Color.green;
                i++;
            }
            else
            {
                i = 0;
                break;
            }
        }
        foreach (GameObject grad in TopSpeedGaugeGrads)
        {
            if (i < stats.TopSpeedStat)
            {
                grad.GetComponent<RawImage>().color = Color.green;
                i++;
            }
            else
            {
                i = 0;
                break;
            }
        }
        foreach (GameObject grad in HandlingGaugeGrads)
        {
            if (i < stats.HandlingStat)
            {
                grad.GetComponent<RawImage>().color = Color.green;
                i++;
            }
            else
            {
                i = 0;
                break;
            }
        }
        #endregion
    }

    #region Button click functions (update the values of the ship's stats)
    public void HealthUpgrade()
    {
        stats.HealthStat += 1;
        int i = 0;
        if (stats.HealthStat >= 5)
        {
            stats.HealthStat = 5;
        }
        foreach (GameObject grad in HealthGaugeGrads)
        {
            if (i < stats.HealthStat)
            {
                grad.GetComponent<RawImage>().color = Color.green;
                i++;
            }
            else
            {
                break;
            }
        }
    }

    public void ArmorUpgrade()
    {
        stats.ArmorStat += 1;
        int i = 0;
        if (stats.ArmorStat >= 5)
        {
            stats.ArmorStat = 5;
        }
        foreach (GameObject grad in ArmorGaugeGrads)
        {
            if (i < stats.ArmorStat)
            {
                grad.GetComponent<RawImage>().color = Color.green;
                i++;
            }
            else
            {
                break;
            }
        }
    }
    public void DamageUpgrade()
    {
        stats.DamageStat += 1;
        int i = 0;
        if (stats.DamageStat >= 5)
        {
            stats.DamageStat = 5;
        }
        foreach (GameObject grad in DamageGaugeGrads)
        {
            if (i < stats.DamageStat)
            {
                grad.GetComponent<RawImage>().color = Color.green;
                i++;
            }
            else
            {
                break;
            }
        }
    }
    public void FireRateUpgrade()
    {
        stats.FireRateStat += 1;
        int i = 0;
        if (stats.FireRateStat >= 5)
        {
            stats.FireRateStat = 5;
        }
        foreach (GameObject grad in FireRateGaugeGrads)
        {
            if (i < stats.FireRateStat)
            {
                grad.GetComponent<RawImage>().color = Color.green;
                i++;
            }
            else
            {
                break;
            }
        }
    }
    public void TopSpeedUpgrade()
    {
        stats.TopSpeedStat += 1;
        int i = 0;
        if (stats.TopSpeedStat >= 5)
        {
            stats.TopSpeedStat = 5;
        }
        foreach (GameObject grad in TopSpeedGaugeGrads)
        {
            if (i < stats.TopSpeedStat)
            {
                grad.GetComponent<RawImage>().color = Color.green;
                i++;
            }
            else
            {
                break;
            }
        }
    }
    public void HandlingUpgrade()
    {
        stats.HandlingStat += 1;
        int i = 0;
        if (stats.HandlingStat >= 5)
        {
            stats.HandlingStat = 5;
        }
        foreach (GameObject grad in HandlingGaugeGrads)
        {
            if (i < stats.HandlingStat)
            {
                grad.GetComponent<RawImage>().color = Color.green;
                i++;
            }
            else
            {
                break;
            }
        }
    }
    #endregion

}
