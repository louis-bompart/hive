using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLauncherScript : MonoBehaviour {

    public new string name = "BombLauncher";
    public int range;
    public int damage;
    public float fireRate;
    public int ammo;

    public GameObject projectile;
    public float shotSpeed;
    public Transform spawnPoint;
    public GameObject reticle;
    public GameObject gauge;
    
    public GameObject Particleprefab;

    private float lastShot;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnFire()
    {
        if(lastShot + fireRate < Time.time)
        {
            GameObject clone;
            clone = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
            clone.GetComponent<ProjectileScript>().SetParent(reticle,gauge,this.gameObject);
            clone.GetComponent<ProjectileScript>().damage = damage;

            clone.GetComponent<Rigidbody>().velocity = spawnPoint.forward * shotSpeed;
            clone.GetComponent<Rigidbody>().velocity += spawnPoint.GetComponentInParent<Rigidbody>().velocity;
            lastShot = Time.time;
        }
       
    }

    public void DestroyEnemyAnimation(Transform DeathTransform) {

        GameObject Particle = Instantiate(Particleprefab, DeathTransform.position, Random.rotation);
        Destroy(Particle, 2);

    }
}
