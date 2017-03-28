using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekForce : AbstractForce
{

    public Transform waypoint;

    public override Vector3 ComputeForce()
    {
        Vector3 force = waypoint.position - gameObject.transform.position;
        if (force.magnitude > 1)
        {
            force = force.normalized;
        }
        return force;
    }
}
