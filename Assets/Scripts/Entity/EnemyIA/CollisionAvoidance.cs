using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAvoidance : AbstractForce {

    public Collider detectionArea;

    List<Collider> listInDetection;
    List<Collider> toRemove;

    void Start()
    {
        listInDetection = new List<Collider>();
        toRemove = new List<Collider>();
    }

    void CollisionAvoidanceEnter(Collider other)
    {
        listInDetection.Add(other);
    }

    void CollisionAvoidanceExit(Collider other)
    {
        listInDetection.Remove(other);
    }

    public override Vector3 ComputeForce()
    {
        Vector3 force = new Vector3(0, 0, 0);
        foreach(Collider act in listInDetection)
        {
            if(act != null)
            {
                Vector3 closestPoint = detectionArea.ClosestPointOnBounds(act.transform.position);
                Vector3 centerToCollision = closestPoint - act.transform.position;
                centerToCollision = centerToCollision.normalized;
                force += centerToCollision;
            }
            else
            {
                toRemove.Add(act);
            }


        }

        foreach(Collider act in toRemove)
        {
            listInDetection.Remove(act);
        }

        return force.normalized;
    }

}
