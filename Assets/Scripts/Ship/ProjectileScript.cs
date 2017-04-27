using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    public GameObject reticle;
    public GameObject gauge;
    public Weapon weapon;
    public float damage;

    public float lifeTime = 3;
    public float StartLife;


    // Use this for initialization
    void Start()
    {
        StartLife = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - StartLife >= lifeTime) Destroy(gameObject);
        
    }

    void OnTriggerEnter(Collider entity)
    {
        //entity.gameObject.GetComponent<AsteroidsDesintegration>().health -= 5;
        //Debug.Log(entity.gameObject.name);
        //Debug.Log(entity.gameObject.GetComponent<AsteroidsDesintegration>().health);
        //Destroy(gameObject)
        Entity temp = entity.GetComponentInParent<Entity>();
        if (temp != null)
        {
            temp.takeDammage((int)damage);
            if (reticle != null)
            {
                reticle.GetComponent<OnHitColorChange>().OnHit();
                if (weapon != null)
                {

                    if ((temp.health <= 0) && (temp.tag == "Enemy"))
                    {
                            weapon.DestroyEnemyAnimation(temp.transform);
                    }
                }
            }
            if (gauge != null && temp.name != "Asteroid")
            {
                gauge.GetComponent<HealthGaugeDisplay>().DisplayHealthOnHit(temp.health, temp.maxHP, temp.name);
            }
        }
        Destroy(gameObject);
    }

    public void SetParent(GameObject _reticle, GameObject _gauge, Weapon _weapon)
    {
        reticle = _reticle;
        gauge = _gauge;
        weapon = _weapon;
    }
}
