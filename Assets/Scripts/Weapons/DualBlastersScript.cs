using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Not good.
public class DualBlastersScript : Weapon {
    

	void Awake(){
		audioSource = GetComponent<AudioSource>();
	}

    override public void OnFire()
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

    public override void DestroyEnemyAnimation(Transform DeathTransform)
    {
        GameObject Particle = Instantiate(Particleprefab, DeathTransform.position, Random.rotation);
        Destroy(Particle, 2);
    }

}
