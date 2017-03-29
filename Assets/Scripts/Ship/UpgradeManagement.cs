using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManagement : MonoBehaviour
{
    #region Gauge preparation
    private List<GameObject> healthGaugeGrads = new List<GameObject>();
    private List<GameObject> armorGaugeGrads = new List<GameObject>();
    private List<GameObject> damageGaugeGrads = new List<GameObject>();
    private List<GameObject> fireRateGaugeGrads = new List<GameObject>();
    private List<GameObject> topSpeedGaugeGrads = new List<GameObject>();
    private List<GameObject> handlingGaugeGrads = new List<GameObject>();
    private ShipStats stats;
    private /*static*/ int healthUp = 0;
    private /*static*/ int armorUp = 0;
    private /*static*/ int damageUp = 0;
    private /*static*/ int fireRateUp = 0;
    private /*static*/ int topSpeedUp = 0;
    private /*static*/ int handlingUp = 0;
    private /*static*/ int defensePoints = 0;
    private /*static*/ int attackPoints = 0;
    private /*static*/ int mobilityPoints = 0;

    public InventoryController inventoryController;

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
        //inventoryController = GameObject.Find("ShipInventoryC").GetComponent<InventoryController>();
        if(inventoryController == null )
        {
            Debug.LogError("InventoryController not attached !", this);
        }
        UpdateUpgradeCount();

        stats = GameObject.Find("Stats").GetComponent<ShipStats>();
        foreach (Transform child in healthGauge.transform)
        {
            healthGaugeGrads.Add(child.gameObject);
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
        foreach (GameObject grad in healthGaugeGrads)
        {
            if (i < stats.healthStat)
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
            if (i < stats.armorStat)
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
            if (i < stats.damageStat)
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
            if (i < stats.fireRateStat)
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
            if (i < stats.topSpeed)
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
            if (i < stats.handlingStat)
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

    private void UpdateUpgradeCount()
    {
       
        defensePoints = inventoryController.GetQuantity(200);
        GameObject.Find("DefenseCounter").GetComponent<Text>().text = defensePoints.ToString();
        attackPoints = inventoryController.GetQuantity(201);
        GameObject.Find("AttackCounter").GetComponent<Text>().text = attackPoints.ToString();
        mobilityPoints = inventoryController.GetQuantity(202);
        GameObject.Find("MobilityCounter").GetComponent<Text>().text = mobilityPoints.ToString();
    }

    #region Button click functions (update the values of the ship's stats)
    public void HealthUpgrade()
    {
        if (defensePoints > 0)
        {
            defensePoints--;
            GameObject.Find("DefenseCounter").GetComponent<Text>().text = defensePoints.ToString();
            healthUp += 1;
            int i = 0;
            if (stats.healthStat + healthUp > 5)
            {
                healthUp = 5 - stats.healthStat;
                defensePoints++;
            }
            foreach (GameObject grad in healthGaugeGrads)
            {
                if (i < healthUp + stats.healthStat)
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
        else
        {
            Debug.Log("Not enough defense upgrade kits !");
        }
    }

    public void ArmorUpgrade()
    {
        if (defensePoints > 0)
        {
            defensePoints--;
            armorUp += 1;
            GameObject.Find("DefenseCounter").GetComponent<Text>().text = defensePoints.ToString();
            int i = 0;
            if (stats.armorStat + armorUp >= 5)
            {
                armorUp = 5 - stats.armorStat;
                defensePoints++;
            }
            foreach (GameObject grad in armorGaugeGrads)
            {
                if (i < armorUp + stats.armorStat)
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
        else
        {
            Debug.Log("Not enough defense upgrade kits !");
        }
    }

    public void DamageUpgrade()
    {
        if (attackPoints > 0)
        {
            attackPoints--;
            GameObject.Find("AttackCounter").GetComponent<Text>().text = attackPoints.ToString();
            damageUp += 1;
            int i = 0;
            if (stats.damageStat + damageUp >= 5)
            {
                damageUp = 5 - stats.damageStat;
                attackPoints++;
            }
            foreach (GameObject grad in damageGaugeGrads)
            {
                if (i < damageUp + stats.damageStat)
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
        else
        {
            Debug.Log("Not enough attack upgrade kits !");
        }
    }

    public void FireRateUpgrade()
    {
        if (attackPoints > 0)
        {
            attackPoints--;
            GameObject.Find("AttackCounter").GetComponent<Text>().text = attackPoints.ToString();
            fireRateUp += 1;
            int i = 0;
            if (stats.fireRateStat + fireRateUp >= 5)
            {
                fireRateUp = 5 - stats.fireRateStat;
                attackPoints++;
            }
            foreach (GameObject grad in fireRateGaugeGrads)
            {
                if (i < fireRateUp + stats.fireRateStat)
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
        else
        {
            Debug.Log("Not enough attack upgrade kits !");
        }
    }

    public void TopSpeedUpgrade()
    {
        if(mobilityPoints > 0)
        {
            mobilityPoints--;
            GameObject.Find("MobilityCounter").GetComponent<Text>().text = mobilityPoints.ToString();
            topSpeedUp += 1;
            int i = 0;
            if (stats.topSpeed + topSpeedUp >= 5)
            {
                topSpeedUp = 5 - stats.topSpeed;
                mobilityPoints++;
            }
            foreach (GameObject grad in topSpeedGaugeGrads)
            {
                if (i < topSpeedUp + stats.topSpeed)
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
        else
        {
            Debug.Log("Not enough mobility upgrade kits !");
        }
    }

    public void HandlingUpgrade()
    {
        if (mobilityPoints > 0)
        {
            mobilityPoints--;
            GameObject.Find("MobilityCounter").GetComponent<Text>().text = mobilityPoints.ToString();
            handlingUp += 1;
            int i = 0;
            if (stats.handlingStat + handlingUp >= 5)
            {
                handlingUp = 5 - stats.handlingStat;
                mobilityPoints++;
            }
            foreach (GameObject grad in handlingGaugeGrads)
            {
                if (i < handlingUp + stats.handlingStat)
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
        else
        {
            Debug.Log("Not enough mobility grade kits !");
        }
    }
    #endregion

    #region Upgrade Validation/cancelation buttons and functions.

    public void Validate()
    {
        stats.healthStat += healthUp;
        stats.armorStat += armorUp;
        stats.damageStat += damageUp;
        stats.fireRateStat += fireRateUp;
        stats.topSpeed += topSpeedUp;
        stats.handlingStat += handlingUp;

        inventoryController.RemoveItem(200, (healthUp + armorUp));
        inventoryController.RemoveItem(201, (damageUp + fireRateUp));
        inventoryController.RemoveItem(202, (topSpeedUp + handlingUp));

        ResetTmpCounters();
        UpdateUpgradeCount();


        foreach (GameObject grad in healthGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.green;
            }
        }
        foreach (GameObject grad in armorGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.green;
            }
        }
        foreach (GameObject grad in damageGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.green;
            }
        }
        foreach (GameObject grad in fireRateGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.green;
            }
        }
        foreach (GameObject grad in topSpeedGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.green;
            }
        }
        foreach (GameObject grad in handlingGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.green;
            }
        }
    }

    private void ResetTmpCounters()
    {
        healthUp = 0;
        armorUp = 0;
        damageUp = 0;
        fireRateUp = 0;
        handlingUp = 0;
        topSpeedUp = 0;
    }

    public void Cancel()
    {
        ResetTmpCounters();
        UpdateUpgradeCount();
        GameObject.Find("DefenseCounter").GetComponent<Text>().text = defensePoints.ToString();
        GameObject.Find("AttackCounter").GetComponent<Text>().text = attackPoints.ToString();
        GameObject.Find("MobilityCounter").GetComponent<Text>().text = mobilityPoints.ToString();
        foreach (GameObject grad in healthGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.white;
            }
        }
        foreach (GameObject grad in armorGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.white;
            }
        }
        foreach (GameObject grad in damageGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.white;
            }
        }
        foreach (GameObject grad in fireRateGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.white;
            }
        }
        foreach (GameObject grad in topSpeedGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.white;
            }
        }
        foreach (GameObject grad in handlingGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.white;
            }
        }
    }
    #endregion
}
