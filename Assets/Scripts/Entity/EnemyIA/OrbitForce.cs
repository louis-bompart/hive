using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitForce : AbstractForce
{

    public Transform waypoint;
    public float orbitDistance;

    private float normalWeight = 1;
    private float tangentWeight = 1;

    public override Vector3 ComputeForce()
    {
        Vector3 shipToTarget = waypoint.position - gameObject.transform.position;

        Vector3 normalForce = shipToTarget;

        float deltaWeight = orbitDistance * 0.0001f;

        if (shipToTarget.magnitude <= 0.7f * orbitDistance)
        {
            normalForce = -normalForce;
            tangentWeight += deltaWeight;
            normalWeight = 1;
        }
        else if (shipToTarget.magnitude <= orbitDistance)
        {
            tangentWeight += deltaWeight;
        }
        else if (shipToTarget.magnitude >= orbitDistance && shipToTarget.magnitude <= orbitDistance * 1.3f)
        {
            normalWeight += deltaWeight;
        }
        else if (shipToTarget.magnitude >= orbitDistance * 1.3)
        {
            normalWeight += deltaWeight;
            tangentWeight = 1;
        }


        Vector3 tangentForce = new Vector3(shipToTarget.y, shipToTarget.z, shipToTarget.x);

        Vector3 force = (normalForce * normalWeight) + (tangentForce * tangentWeight);

        if (force.magnitude > 1)
        {
            force = force.normalized;
        }
        return force;
    }
}
