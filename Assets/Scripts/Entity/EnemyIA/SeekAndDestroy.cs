using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekAndDestroy : MonoBehaviour
{

    List<Collider> detectedTargets;
    public string tagToAttack;

    Transform target;

    public void Start()
    {
        detectedTargets = new List<Collider>();
    }

    public void Update()
    {
        if (target != null)
        {
            WeaponSelector temp = gameObject.GetComponent<WeaponSelector>();
            if (temp != null)
            {
                temp.weapons[temp.currentWeapon].SendMessage("OnFire");
            }
        }
    }

    public void OnDetectionAreaEnter(Collider other)
    {
        if (other.tag == tagToAttack)
        {
            detectedTargets.Add(other);
            UpdateBehavior();
        }

    }

    public void OnDetectionAreaExit(Collider other)
    {
        detectedTargets.Remove(other);
        UpdateBehavior();
    }

    public void UpdateBehavior()
    {
        if (detectedTargets.Count >= 1)
        {
            target = detectedTargets[0].GetComponentInParent<Entity>().transform;

            GetComponent<BasicFlightControl>().newPursuiteForce(target, 15, 1f, 1f, 1f, true);

            foreach (OrbitForce act in GetComponents<OrbitForce>())
            {
                act.enabled = false;
            }

            foreach (WanderForce act in GetComponents<WanderForce>())
            {
                act.enabled = false;
            }
        }
        else
        {
            foreach (PursuitForce act in GetComponents<PursuitForce>())
            {
                Destroy(act);
            }

            foreach (OrbitForce act in GetComponents<OrbitForce>())
            {
                act.enabled = true;
            }

            foreach (WanderForce act in GetComponents<WanderForce>())
            {
                act.enabled = true;
            }

            target = null;
        }
    }
}
