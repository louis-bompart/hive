using UnityEngine;
using System.Collections;

public class PrimaryWeaponScript : MonoBehaviour
{
    public GameObject projectile;
    public Transform Spawnpoint;
    public float shotspeed;
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
            clone = Instantiate(projectile, Spawnpoint.position, projectile.GetComponent<Rigidbody>().rotation);

            clone.GetComponent<Rigidbody>().velocity = Spawnpoint.forward * shotspeed;
        }
    }
}