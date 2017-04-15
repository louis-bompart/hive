using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity {

    protected override void Start()
    {
        base.Start();
        name = "Red Raven";
    }

    protected override void Update()
    {
        base.Update();
        

    }

    protected override void endOfLife()
    {
        GameObject.Find("Data").GetComponentInChildren<OtherStats>().DestroyedEnemies++;
        base.endOfLife();
    }

}
