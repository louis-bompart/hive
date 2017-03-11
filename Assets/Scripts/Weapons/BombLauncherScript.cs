using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLauncherScript : MonoBehaviour {

    public int range;
    public int damage;
    public int firerate;
    public int ammo;

    public GameObject projectile;
    public float shotspeed;
    public Transform Spawnpoint;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetButtonDown("Fire1"))
        {
            GameObject clone;
            clone = Instantiate(projectile, Spawnpoint.position, Spawnpoint.rotation);

            clone.GetComponent<Rigidbody>().velocity = Spawnpoint.forward * shotspeed;
            clone.GetComponent<Rigidbody>().velocity += gameObject.GetComponentInParent<Rigidbody>().velocity;
        }
    }
}
