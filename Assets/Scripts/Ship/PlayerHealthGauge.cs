using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthGauge : MonoBehaviour {

    
    public Player player;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        GetComponentInChildren<Slider>().maxValue = player.maxHP;
        GetComponentInChildren<Slider>().value = player.health;
	}
}
