using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseUpgradeManager : MonoBehaviour
{
    #region Gauge preparation
    private List<GameObject> HealthGaugeGrads = new List<GameObject>();
    private List<GameObject> ArmorGaugeGrads = new List<GameObject>();
    private List<GameObject> DamageGaugeGrads = new List<GameObject>();
    private List<GameObject> FireRateGaugeGrads = new List<GameObject>();
    private List<GameObject> TopSpeedGaugeGrads = new List<GameObject>();
    private List<GameObject> HandlingGaugeGrads = new List<GameObject>();
    private BaseStats stats;
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
        stats = GameObject.Find("Stats").GetComponent<BaseStats>();
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
            if (i < stats.ScanRangeStat)
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
            if (i < stats.printerStat)
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
            if (i < stats.NumberDroneStat)
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
            if (i < stats.fireDroneStat)
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
            if (i < stats.ShieldStat)
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
            if (i < stats.RechargeStat)
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
        stats.ScanRangeStat += 1;
        int i = 0;
        if (stats.ScanRangeStat >= 5)
        {
            stats.ScanRangeStat = 5;
        }
        foreach (GameObject grad in HealthGaugeGrads)
        {
            if (i < stats.ScanRangeStat)
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
        stats.printerStat += 1;
        int i = 0;
        if (stats.printerStat >= 5)
        {
            stats.printerStat = 5;
        }
        foreach (GameObject grad in ArmorGaugeGrads)
        {
            if (i < stats.printerStat)
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
        stats.NumberDroneStat += 1;
        int i = 0;
        if (stats.NumberDroneStat >= 5)
        {
            stats.NumberDroneStat = 5;
        }
        foreach (GameObject grad in DamageGaugeGrads)
        {
            if (i < stats.NumberDroneStat)
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
        stats.fireDroneStat += 1;
        int i = 0;
        if (stats.fireDroneStat >= 5)
        {
            stats.fireDroneStat = 5;
        }
        foreach (GameObject grad in FireRateGaugeGrads)
        {
            if (i < stats.fireDroneStat)
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
        stats.ShieldStat += 1;
        int i = 0;
        if (stats.ShieldStat >= 5)
        {
            stats.ShieldStat = 5;
        }
        foreach (GameObject grad in TopSpeedGaugeGrads)
        {
            if (i < stats.ShieldStat)
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
        stats.RechargeStat += 1;
        int i = 0;
        if (stats.RechargeStat >= 5)
        {
            stats.RechargeStat = 5;
        }
        foreach (GameObject grad in HandlingGaugeGrads)
        {
            if (i < stats.RechargeStat)
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
