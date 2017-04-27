using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderForce : AbstractForce
{

    private float circleRadius = 1;
    private float turnChance = 0.01f;
    //private float maxRadius = 4;


    private Vector3 velocity;
    private Vector3 wanderForce;
    private Vector3 target;


    public override Vector3 ComputeForce()
    {
        return GetWanderForce().normalized;
    }

    private Vector3 GetWanderForce()
    {

        if (UnityEngine.Random.value < turnChance)
        {
            wanderForce = GetRandomWanderForce();
        }

        return wanderForce;
    }

    private Vector3 GetRandomWanderForce()
    {
        Vector3 circleCenter = gameObject.transform.forward.normalized;
        Vector2 randomPoint = UnityEngine.Random.insideUnitCircle;

        Vector3 displacement = new Vector3(randomPoint.x, randomPoint.y) * circleRadius;
        displacement = Quaternion.LookRotation(transform.forward) * displacement;

        Vector3 wanderForce = circleCenter + displacement;
        return wanderForce;
    }
}
