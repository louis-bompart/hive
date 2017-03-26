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
    private static int HealthUp = 0;
    private static int ArmorUp = 0;
    private static int DamageUp = 0;
    private static int FireRateUp = 0;
    private static int TopSpeedUp = 0;
    private static int HandlingUp = 0;

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
        HealthUp += 1;
        int i = 0;
        if (stats.HealthStat + HealthUp >= 5)
        {
            HealthUp = 5 - stats.HealthStat;
        }
        foreach (GameObject grad in HealthGaugeGrads)
        {
            if (i < HealthUp + stats.HealthStat)
            {
                if (grad.GetComponent<RawImage>().color == Color.white)
                {
                    grad.GetComponent<RawImage>().color = Color.yellow;
                    i++;
                }
                else
                {
                    i++;
                }
            }
        }
    }

    public void ArmorUpgrade()
    {
        ArmorUp += 1;
        int i = 0;
        if (stats.ArmorStat + ArmorUp >= 5)
        {
            ArmorUp = 5 - stats.ArmorStat;
        }
        foreach (GameObject grad in ArmorGaugeGrads)
        {
            if (i < ArmorUp + stats.ArmorStat)
            {
                if (grad.GetComponent<RawImage>().color == Color.white)
                {
                    grad.GetComponent<RawImage>().color = Color.yellow;
                    i++;
                }
                else
                {
                    i++;
                }
            }
        }
    }
    public void DamageUpgrade()
    {
        DamageUp += 1;
        int i = 0;
        if (stats.DamageStat + DamageUp >= 5)
        {
            DamageUp = 5 - stats.DamageStat;
        }
        foreach (GameObject grad in DamageGaugeGrads)
        {
            if (i < DamageUp + stats.DamageStat)
            {
                if (grad.GetComponent<RawImage>().color == Color.white)
                {
                    grad.GetComponent<RawImage>().color = Color.yellow;
                    i++;
                }
                else
                {
                    i++;
                }
            }
        }
    }
    public void FireRateUpgrade()
    {
        FireRateUp += 1;
        int i = 0;
        if (stats.FireRateStat + FireRateUp >= 5)
        {
            FireRateUp = 5 - stats.FireRateStat;
        }
        foreach (GameObject grad in FireRateGaugeGrads)
        {
            if (i < FireRateUp + stats.FireRateStat)
            {
                if (grad.GetComponent<RawImage>().color == Color.white)
                {
                    grad.GetComponent<RawImage>().color = Color.yellow;
                    i++;
                }
                else
                {
                    i++;
                }
            }
        }
    }
    public void TopSpeedUpgrade()
    {
        TopSpeedUp += 1;
        int i = 0;
        if (stats.TopSpeedStat + TopSpeedUp >= 5)
        {
            TopSpeedUp = 5 - stats.TopSpeedStat;
        }
        foreach (GameObject grad in TopSpeedGaugeGrads)
        {
            if (i < TopSpeedUp + stats.TopSpeedStat)
            {
                if (grad.GetComponent<RawImage>().color == Color.white)
                {
                    grad.GetComponent<RawImage>().color = Color.yellow;
                    i++;
                }
                else
                {
                    i++;
                }
            }
        }
    }
    public void HandlingUpgrade()
    {
        HandlingUp += 1;
        int i = 0;
        if (stats.HandlingStat + HandlingUp >= 5)
        {
            HandlingUp = 5 - stats.HandlingStat;
        }
        foreach (GameObject grad in HandlingGaugeGrads)
        {
            if (i < HandlingUp + stats.HandlingStat)
            {
                if (grad.GetComponent<RawImage>().color == Color.white)
                {
                    grad.GetComponent<RawImage>().color = Color.yellow;
                    i++;
                }
                else
                {
                    i++;
                }
            }
        }
    }
    #endregion

    #region Upgrade Validation/cancelation buttons and functions.

    public void Validate()
    {
        stats.HealthStat += HealthUp;
        stats.ArmorStat += ArmorUp;
        stats.DamageStat += DamageUp;
        stats.FireRateStat += FireRateUp;
        stats.TopSpeedStat += TopSpeedUp;
        stats.HandlingStat += HandlingUp;
        foreach (GameObject grad in HealthGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.green;
            }
        }
        foreach (GameObject grad in ArmorGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.green;
            }
        }
        foreach (GameObject grad in DamageGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.green;
            }
        }
        foreach (GameObject grad in FireRateGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.green;
            }
        }
        foreach (GameObject grad in TopSpeedGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.green;
            }
        }
        foreach (GameObject grad in HandlingGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.green;
            }
        }
    }

    public void Cancel()
    {
        HealthUp = 0;
        ArmorUp = 0;
        DamageUp = 0;
        FireRateUp = 0;
        TopSpeedUp = 0;
        HandlingUp = 0;

        foreach (GameObject grad in HealthGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.white;
            }
        }
        foreach (GameObject grad in ArmorGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.white;
            }
        }
        foreach (GameObject grad in DamageGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.white;
            }
        }
        foreach (GameObject grad in FireRateGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.white;
            }
        }
        foreach (GameObject grad in TopSpeedGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.white;
            }
        }
        foreach (GameObject grad in HandlingGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.white;
            }
        }
    }
    #endregion
}
