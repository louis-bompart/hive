using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderForce : AbstratForce {

    private float CircleRadius = 1;
    private float TurnChance = 0.01f;
    private float MaxRadius = 4;


    private Vector3 velocity;
    private Vector3 wanderForce;
    private Vector3 target;


    public override Vector3 CalculateForce()
    {
        return GetWanderForce().normalized;
    }



    private Vector3 GetWanderForce()
    {

        if (UnityEngine.Random.value < TurnChance)
        {
            wanderForce = GetRandomWanderForce();
        }

        return wanderForce;
    }

    private Vector3 GetRandomWanderForce()
    {
        Vector3 circleCenter = gameObject.transform.forward.normalized;
        Vector2 randomPoint = UnityEngine.Random.insideUnitCircle;

        Vector3 displacement = new Vector3(randomPoint.x, randomPoint.y) * CircleRadius;
        displacement = Quaternion.LookRotation(transform.forward) * displacement;

        Vector3 wanderForce = circleCenter + displacement;
        return wanderForce;
    }
}
