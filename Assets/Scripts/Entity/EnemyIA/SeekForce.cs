using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekForce : AbstratForce
{

    public Transform wayPoint;

    public override Vector3 CalculateForce()
    {
        Vector3 force = wayPoint.position - gameObject.transform.position;
        if(force.magnitude>1)
        {
            force = force.normalized;
        }
        return force;
    }
}
