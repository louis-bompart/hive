using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseUpgradeManager : MonoBehaviour
{
    #region Gauge preparation
    private List<GameObject> healtGaugeGrads = new List<GameObject>();
    private List<GameObject> armorGaugeGrads = new List<GameObject>();
    private List<GameObject> damageGaugeGrads = new List<GameObject>();
    private List<GameObject> fireRateGaugeGrads = new List<GameObject>();
    private List<GameObject> topSpeedGaugeGrads = new List<GameObject>();
    private List<GameObject> handlingGaugeGrads = new List<GameObject>();
    private BaseStats stats;
    #endregion

    public void Start()
    {
        #region Gauge init
        GameObject healthGauge = GameObject.Find("HealthUpgradeGauge");
        GameObject armorGauge = GameObject.Find("ArmorUpgradeGauge");
        GameObject damageGauge = GameObject.Find("DamageUpgradeGauge");
        GameObject fireRateGauge = GameObject.Find("FireRateUpgradeGauge");
        GameObject topSpeedGauge = GameObject.Find("TopSpeedUpgradeGauge");
        GameObject handlingGauge = GameObject.Find("HandlingUpgradeGauge");
        stats = GameObject.Find("Stats").GetComponent<BaseStats>();
        foreach (Transform child in healthGauge.transform)
        {
            healtGaugeGrads.Add(child.gameObject);
        }
        foreach (Transform child in armorGauge.transform)
        {
            armorGaugeGrads.Add(child.gameObject);
        }
        foreach (Transform child in damageGauge.transform)
        {
            damageGaugeGrads.Add(child.gameObject);
        }
        foreach (Transform child in fireRateGauge.transform)
        {
            fireRateGaugeGrads.Add(child.gameObject);
        }
        foreach (Transform child in topSpeedGauge.transform)
        {
            topSpeedGaugeGrads.Add(child.gameObject);
        }
        foreach (Transform child in handlingGauge.transform)
        {
            handlingGaugeGrads.Add(child.gameObject);
        }

        int i = 0;
        foreach (GameObject grad in healtGaugeGrads)
        {
            if (i < stats.scanRangeStat)
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
        foreach (GameObject grad in armorGaugeGrads)
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
        foreach (GameObject grad in damageGaugeGrads)
        {
            if (i < stats.numberDronesStat)
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
        foreach (GameObject grad in fireRateGaugeGrads)
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
        foreach (GameObject grad in topSpeedGaugeGrads)
        {
            if (i < stats.shieldStat)
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
        foreach (GameObject grad in handlingGaugeGrads)
        {
            if (i < stats.chargeStat)
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
        stats.scanRangeStat += 1;
        int i = 0;
        if (stats.scanRangeStat >= 5)
        {
            stats.scanRangeStat = 5;
        }
        foreach (GameObject grad in healtGaugeGrads)
        {
            if (i < stats.scanRangeStat)
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
        foreach (GameObject grad in armorGaugeGrads)
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
        stats.numberDronesStat += 1;
        int i = 0;
        if (stats.numberDronesStat >= 5)
        {
            stats.numberDronesStat = 5;
        }
        foreach (GameObject grad in damageGaugeGrads)
        {
            if (i < stats.numberDronesStat)
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
        foreach (GameObject grad in fireRateGaugeGrads)
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
        stats.shieldStat += 1;
        int i = 0;
        if (stats.shieldStat >= 5)
        {
            stats.shieldStat = 5;
        }
        foreach (GameObject grad in topSpeedGaugeGrads)
        {
            if (i < stats.shieldStat)
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
        stats.chargeStat += 1;
        int i = 0;
        if (stats.chargeStat >= 5)
        {
            stats.chargeStat = 5;
        }
        foreach (GameObject grad in handlingGaugeGrads)
        {
            if (i < stats.chargeStat)
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
