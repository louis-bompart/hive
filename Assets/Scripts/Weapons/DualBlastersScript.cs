using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualBlastersScript : MonoBehaviour {

    public int range;
    public int damage;
    public float firerate;
    public int ammo;

    public GameObject projectile;
    public float shotspeed;
    public Transform Spawnpoint;

    private float lastShot;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void OnFire()
    {
        if (lastShot + firerate < Time.time)
        {
            GameObject clone;
            clone = Instantiate(projectile, Spawnpoint.position, Spawnpoint.rotation);

            clone.GetComponent<Rigidbody>().velocity = Spawnpoint.forward * shotspeed;
            clone.GetComponent<Rigidbody>().velocity += Spawnpoint.GetComponentInParent<Rigidbody>().velocity;
            lastShot = Time.time;
        }

    }

}
