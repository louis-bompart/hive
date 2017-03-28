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
    public GameObject parent;

    private float lastShot;
    private ShipStats stats;

    // Use this for initialization
    void Start () {
        stats = GameObject.Find("Stats").GetComponent<ShipStats>();
	}
	
	// Update is called once per frame
	void Update () {
        firerate = 2 - (stats.FireRateStat * 0.35f);
    }

    public void OnFire()
    {
        if (lastShot + firerate < Time.time)
        {
            GameObject clone;
            clone = Instantiate(projectile, Spawnpoint.position, Spawnpoint.rotation);
            clone.GetComponent<ProjectileScript>().SetParent(parent);
            //clone.GetComponent<ProjectileScript>().dammage = damage;

            clone.GetComponent<Rigidbody>().velocity = Spawnpoint.forward * shotspeed;
            clone.GetComponent<Rigidbody>().velocity += Spawnpoint.GetComponentInParent<Rigidbody>().velocity;
            lastShot = Time.time;
        }

    }

}
