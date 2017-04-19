using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthGaugeDisplay : MonoBehaviour {

    public float HealthGaugeDisplayTime;
    public Slider HealthGaugeSlider;
    public GameObject HealthGauge;
    public GameObject HealthGaugeText;

    // Use this for initialization
    void Start () {
        HealthGauge.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DisplayHealthOnHit(float health,float maxHP,string name)
    {
        HealthGauge.SetActive(true);
        StartCoroutine(DisplayHealthGauge(HealthGaugeDisplayTime, health, maxHP, name));


    }

    public IEnumerator DisplayHealthGauge(float HealthGaugeDisplayTime, float health, float maxHP, string name) {
        HealthGaugeSlider.maxValue = maxHP;
        HealthGaugeSlider.value = health;
        HealthGaugeText.GetComponent<Text>().text = name;
        if (HealthGaugeDisplayTime != 0)
        {
            yield return new WaitForSeconds(HealthGaugeDisplayTime);
            HealthGauge.SetActive(false);
        }

    }
}
