using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocateAndDestroy : MonoBehaviour {

    List<Collider> detectedTargets;
    public string tagToAttack;

    Transform target;

    public void Start()
    {
        detectedTargets = new List<Collider>();
    }

    public void Update()
    {
        if(target!=null)
        {
            WeaponSelector temp = gameObject.GetComponent<WeaponSelector>();
            if(temp!=null)
            {
                temp.weapons[temp.currentWeapon].BroadcastMessage("OnFire");
            }
        }
    }

    public void DetectionZoneEnter(Collider other)
    {
        if (other.tag == tagToAttack)
        {
            detectedTargets.Add(other);
            updateBehavior();
        }   
        
    }

    public void DetectionZoneExit(Collider other)
    {
        detectedTargets.Remove(other);
        updateBehavior();
    }

    public void updateBehavior()
    {
        if(detectedTargets.Count>=1)
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
            Debug.Log("All target Lost");
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
