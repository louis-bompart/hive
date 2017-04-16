using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiningLaserScript : MonoBehaviour
{
    LineRenderer line;
    GameObject particleObject;
    ParticleSystem particle;
    ParticleSystem.EmissionModule em;
    public GameObject particlePrefab;
    public int range = 50;
    public Slider healthGauge;
    public GameObject healthGaugeText;

	public AudioClip laserSound;

	private AudioSource source;

	void Awake(){
		source = GetComponent<AudioSource> ();
	}

    void Start()
    {
        healthGaugeText.SetActive(false);
        healthGauge.gameObject.SetActive(false);
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

    void Update()
    {
		if (Input.GetButtonDown ("Fire2")) {
			StopCoroutine ("FireMiningLaser");
			StartCoroutine ("FireMiningLaser");
		} else {
			if (source.isPlaying) {
				source.Stop ();
			}
		}
    }

    IEnumerator FireMiningLaser()
    {
        line.enabled = true;
        while (Input.GetButton("Fire2"))
        {
            line.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, Time.time);
            Ray miningray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            line.SetPosition(0, miningray.origin);

			source.Play ();

            if (Physics.Raycast(miningray, out hit, range))
            {
                line.SetPosition(1, hit.point);
                Asteroid asscript = hit.transform.gameObject.GetComponent<Asteroid>();
                if (asscript != null)
                {
                    healthGauge.gameObject.SetActive(true);
                    healthGaugeText.SetActive(true);
                    asscript.health -= 1;
                    healthGauge.value = asscript.health/(asscript.maxHP + 1);
                    if (asscript.health <= 0)
                    {
                        GameObject Particle = Instantiate(particlePrefab, hit.point, Random.rotation);
                        Particle.transform.localScale = asscript.transform.localScale;
                        GameObject.Find("Data").GetComponentInChildren<OtherStats>().DestroyedAsteroids++;
                        Destroy(Particle, 2);
                    }
                }

                particleObject.transform.position = hit.point;
                em.enabled = true;
            }
            else
            {
                line.SetPosition(1, miningray.GetPoint(range));
                healthGaugeText.SetActive(false);
                healthGauge.gameObject.SetActive(false);
                em.enabled = false;
            }

            yield return null;
        }

        healthGaugeText.SetActive(false);
        healthGauge.gameObject.SetActive(false);
        line.enabled = false;
        em.enabled = false;
    }
}
