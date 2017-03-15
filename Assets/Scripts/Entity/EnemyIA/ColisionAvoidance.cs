using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionAvoidance : AbstratForce {

    public Collider zoneDetection;

    List<Collider> listInDetection;

    void Start()
    {
        listInDetection = new List<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        listInDetection.Add(other);
    }

    void OnTriggerExit(Collider other)
    {
        listInDetection.Remove(other);
    }

    public override Vector3 CalculateForce()
    {
        Vector3 ret = new Vector3(0, 0, 0);
        foreach(Collider act in listInDetection)
        {
            Vector3 closestPoint = zoneDetection.ClosestPointOnBounds(act.transform.position);
            Vector3 centerToCollision = closestPoint - act.transform.position;
            centerToCollision = centerToCollision.normalized;
            ret += centerToCollision;


        }

        return ret.normalized;
    }

}
