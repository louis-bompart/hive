using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity {

    private ShipStats stats;
    protected override void Start()
    {
        base.Start();
        stats = GameObject.Find("Stats").GetComponent<ShipStats>();
        maxHP = 100 + (stats.healthStat * 50);
        health = maxHP;
    }

    protected override void Update()
    {
        base.Update();
    }
    

}
