using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitForce : AbstratForce
{

    public Transform wayPoint;
    public float orbitDistance;

    private float normalWeight = 1;
    private float tangeantWeight = 1;

    public override Vector3 CalculateForce()
    {


        Vector3 shipToTarget = wayPoint.position - gameObject.transform.position;
        
        Vector3 normalForce = shipToTarget;

        float deltaWeight = orbitDistance * 0.0001f;

        if(shipToTarget.magnitude <= 0.7f * orbitDistance)
        {
            normalForce = -normalForce;
            tangeantWeight += deltaWeight;
            normalWeight = 1;
        }
        else if(shipToTarget.magnitude <= orbitDistance)
        {
            tangeantWeight += deltaWeight;
        }
        else if(shipToTarget.magnitude >= orbitDistance && shipToTarget.magnitude<=orbitDistance*1.3f)
        {
            normalWeight += deltaWeight;
        }
        else if(shipToTarget.magnitude >= orbitDistance * 1.3)
        {
            normalWeight += deltaWeight;
            tangeantWeight = 1;
        }


        Vector3 tangeantForce = new Vector3(shipToTarget.y, shipToTarget.z, shipToTarget.x);

        Vector3 force = (normalForce * normalWeight) + (tangeantForce*tangeantWeight);

        if(force.magnitude>1)
        {
            force = force.normalized;
        }
        return force;
    }
}
