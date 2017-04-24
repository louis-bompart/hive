using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    protected override void endOfLife()
    {
        //base.endOfLife();
        SceneManager.LoadSceneAsync("GameOver", LoadSceneMode.Single);
    }


}
