using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFlightControl : MonoBehaviour
{

    Entity parent;
    Rigidbody rb;

    public float mainThrust = 5.0f;
    public float auxThrust = 2.5f;
    public float rotationSpeed = 0.01f;

    protected void Start()
    {
        parent = GetComponent<Entity>();
        if (parent == null)
        {
            enabled = false;
        }

        rb = GetComponent<Rigidbody>();

    }

    public void FixedUpdate()
    {
        Vector3 force = ComputeForce();
        //Forward axis
        Vector3 forwardForce = Vector3.Project(force, gameObject.transform.forward);
        if (forwardForce.magnitude >= mainThrust)
        {

            forwardForce = forwardForce.normalized;
            forwardForce *= mainThrust;
        }

        rb.AddForce(forwardForce);

        //Up axis
        Vector3 upForce = Vector3.Project(force, gameObject.transform.up);
        if (upForce.magnitude >= auxThrust)
        {

            upForce = upForce.normalized;
            upForce *= auxThrust;
        }

        rb.AddForce(upForce);

        //Red axis
        Vector3 rightForce = Vector3.Project(force, gameObject.transform.right);
        if (rightForce.magnitude >= auxThrust)
        {
            rightForce = rightForce.normalized;
            rightForce *= auxThrust;
        }


        rb.AddForce(rightForce);

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, force, rotationSpeed, 0.0F);
        transform.rotation = Quaternion.LookRotation(newDirection);

    }

    /// <summary>
    /// Compute the desired force for the next frame
    /// </summary>
    /// <returns></returns>
    public Vector3 ComputeForce()
    {
        AbstractForce[] tabForce = GetComponents<AbstractForce>();
        Vector3 totalForce = new Vector3();
        foreach (AbstractForce abstractForce in tabForce)
        {
            if (abstractForce.enabled == true)
            {
                totalForce += abstractForce.ComputeForce().normalized * abstractForce.weight;
            }
        }
        return totalForce;
    }

    public void newSeekForce(Transform waypoint, float weight = 1)
    {
        SeekForce temp = gameObject.AddComponent<SeekForce>();
        temp.waypoint = waypoint;
        temp.weight = weight;
        temp.enabled = true;
    }

    public void newCollisionAvoidanceForce(Collider col, float weight = 1)
    {
        CollisionAvoidance temp = gameObject.AddComponent<CollisionAvoidance>();
        temp.detectionArea = col;
        temp.weight = weight;
        temp.enabled = true;
    }

    public void newWanderForce(float weight = 1)
    {
        WanderForce temp = gameObject.AddComponent<WanderForce>();
        temp.weight = weight;
        temp.enabled = true;
    }

    public void newOrbitForce(Transform waypoint, float distance = 10, float weight = 1)
    {
        OrbitForce temp = gameObject.AddComponent<OrbitForce>();
        temp.waypoint = waypoint;
        temp.orbitDistance = distance;
        temp.weight = weight;
        temp.enabled = true;
    }

    public void newPursuiteForce(Transform waypoint, float weight = 1, float forward = 0, float right = 0, float up = 0, bool useVelocity = true)
    {
        PursuitForce temp = gameObject.AddComponent<PursuitForce>();
        temp.waypoint = waypoint;
        temp.weight = weight;
        temp.offsetForward = forward;
        temp.offsetRight = right;
        temp.offsetUp = up;
        temp.useTargetVelocity = useVelocity;
        temp.enabled = true;
    }
}
