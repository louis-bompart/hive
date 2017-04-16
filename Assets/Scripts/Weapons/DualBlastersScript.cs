using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Not good.
public class DualBlastersScript : Weapon {

    public string weaponName = "DualBlasters";


	void Awake(){
		audioSource = GetComponent<AudioSource>();
	}
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void OnFire()
    {
        if (lastShot + fireRate < Time.time)
        {
			audioSource.PlayOneShot (shotSound);
            GameObject clone;
            clone = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
            clone.GetComponent<ProjectileScript>().SetParent(Reticle,Gauge,this);
            clone.GetComponent<ProjectileScript>().damage = damage;

            clone.GetComponent<Rigidbody>().velocity = spawnPoint.forward * shotSpeed;
            clone.GetComponent<Rigidbody>().velocity += spawnPoint.GetComponentInParent<Rigidbody>().velocity;
            lastShot = Time.time;
        }

    }

    public void DestroyEnemyAnimation(Transform DeathTransform)
    {
        GameObject Particle = Instantiate(Particleprefab, DeathTransform.position, Random.rotation);
        Destroy(Particle, 2);
    }

}
