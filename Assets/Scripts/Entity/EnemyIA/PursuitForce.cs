using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitForce : AbstractForce
{

    public Transform waypoint;
    public float offsetForward;
    public float offsetRight;
    public float offsetUp;
    public bool useTargetVelocity;

    public override Vector3 ComputeForce()
    {
        if(waypoint == null)
        {
            this.enabled = false;
            return new Vector3(0,0,0);
        }
        Vector3 offWaypoint = waypoint.position;


        Rigidbody rb = waypoint.gameObject.GetComponent<Rigidbody>();
        if (useTargetVelocity == true && rb != null)
        {
            Vector3 vel = rb.velocity;
            Vector3 forwardOff = Vector3.Project(vel, waypoint.forward);
            forwardOff *= offsetForward;
            Vector3 rightOff = Vector3.Project(vel, waypoint.right);
            rightOff *= offsetRight;
            Vector3 upOff = Vector3.Project(vel, waypoint.up);
            upOff *= offsetUp;

            offWaypoint += forwardOff;
            offWaypoint += rightOff;
            offWaypoint += upOff;
        }
        else
        {
            offWaypoint += waypoint.forward * offsetForward;
            offWaypoint += waypoint.right * offsetRight;
            offWaypoint += waypoint.up * offsetUp;
        }

        Vector3 force = offWaypoint - transform.position;

        if (force.magnitude > 1)
        {
            force = force.normalized;
        }
        return force;
    }
}
