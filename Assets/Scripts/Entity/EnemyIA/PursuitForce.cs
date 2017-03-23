using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitForce : AbstratForce
{

    public Transform wayPoint;
    public float offSetForward;
    public float offSetRight;
    public float offSetUp;
    public bool useTargeVelocity;

    public override Vector3 CalculateForce()
    {
        Vector3 offWaypoint = wayPoint.position;
        

        Rigidbody rb = wayPoint.gameObject.GetComponent<Rigidbody>();
        if(useTargeVelocity == true  &&  rb != null)
        {
            Vector3 vel = rb.velocity;
            Vector3 forwardOff = Vector3.Project(vel, wayPoint.forward);
            forwardOff *= offSetForward;
            Vector3 rightOff = Vector3.Project(vel, wayPoint.right);
            rightOff *= offSetRight;
            Vector3 upOff = Vector3.Project(vel, wayPoint.up);
            upOff *= offSetUp;

            offWaypoint += forwardOff;
            offWaypoint += rightOff;
            offWaypoint += upOff;
        }
        else
        {
            offWaypoint += wayPoint.forward * offSetForward;
            offWaypoint += wayPoint.right * offSetRight;
            offWaypoint += wayPoint.up * offSetUp;
        }

        Vector3 force = offWaypoint - transform.position;

        if(force.magnitude>1)
        {
            force = force.normalized;
        }
        return force;
    }
}
