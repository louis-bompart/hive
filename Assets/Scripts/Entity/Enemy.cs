using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity {

    public float MainThrust = 5.0f;
    public float AuxThrust = 2.5f;
    public float Torque = 2.5f;

    BasicFlightControl iaEnemy;

    Rigidbody rb;

    protected override void Start()
    {
        base.Start();
        iaEnemy = new BasicFlightControl(this);
        rb = GetComponentInParent<Rigidbody>();
    }

    protected override void Update()
    {
        base.Update();
        Vector3 force = iaEnemy.CalculateForces();
        Vector3 forwardForce = Vector3.Project(force, gameObject.transform.forward);
        if(forwardForce.magnitude >= MainThrust)
        {
            forwardForce = forwardForce.normalized;
            forwardForce *= MainThrust;
        }
        rb.AddForce(forwardForce);

    }

}
