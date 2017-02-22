using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningLaserScript : MonoBehaviour {

    LineRenderer line;
    GameObject particleObject;
    ParticleSystem particle;
    ParticleSystem.EmissionModule em;
    public GameObject Particleprefab;
    public int range = 50;

    void Start ()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.enabled = false;
        particleObject = Instantiate(gameObject);
        Destroy(particleObject.GetComponent<LineRenderer>());
        Destroy(particleObject.GetComponent<MiningLaserScript>());
        particle = particleObject.GetComponent<ParticleSystem>();
        em = particle.emission;
        em.enabled = false;
        gameObject.GetComponent<ParticleSystem>().Stop();
    }
	
	void Update ()
    {
		if(Input.GetButtonDown("Fire2"))
        {
            StopCoroutine("FireMiningLaser");
            StartCoroutine("FireMiningLaser");
        }
	}
    
    IEnumerator FireMiningLaser()
    {
        line.enabled = true;
        while(Input.GetButton("Fire2"))
        {
            line.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, Time.time);
            Ray miningray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            line.SetPosition(0, miningray.origin);

            if (Physics.Raycast(miningray, out hit, range))
            {
                line.SetPosition(1, hit.point);
                Asteroid asscript = hit.transform.gameObject.GetComponent<Asteroid>();
                if (asscript != null)
                {
                    if (!asscript.takeDammage(1))
                    {
                        GameObject Particle = Instantiate(Particleprefab, hit.point, Random.rotation);
                        Particle.transform.localScale = asscript.transform.localScale;
                        Destroy(Particle,2000);
                    }
                }
                
                particleObject.transform.position = hit.point;
                em.enabled = true;
            }                
            else
            {
                line.SetPosition(1, miningray.GetPoint(range));
                em.enabled = false;
            }


            yield return null;
        }

        line.enabled = false;
        em.enabled = false;
    }
}
