using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Entity
{
    //In health/seconde
    public float shieldRechargeRate;

    private float lastUpdate;
    private float deltaPool;

    private void Awake()
    {
        name = "Hive Station Shield";
    }
    // Use this for initialization
    /*
     * protected override void Start () {
		
	}*/

    // Update is called once per frame
    protected override void Update()
    {


        deltaPool += Time.time - lastUpdate;
        lastUpdate = Time.time;

        if (deltaPool >= 1)
        {
            health += shieldRechargeRate;
            deltaPool = 0;
        }

    }
}
