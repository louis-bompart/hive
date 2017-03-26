using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {
    private ShipStats stats;
    public GameObject parent;
	// Use this for initialization
	void Start () {
        stats = GameObject.Find("Stats").GetComponent<ShipStats>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider entity)
    {      
        //entity.gameObject.GetComponent<AsteroidsDesintegration>().health -= 5;
        Debug.Log(entity.gameObject.name);
        //Debug.Log(entity.gameObject.GetComponent<AsteroidsDesintegration>().health);
        //Destroy(gameObject)
        Entity temp = entity.GetComponentInParent<Entity>();
        if(temp != null)
        {
            temp.takeDammage((stats.DamageStat+1) * 5);
            parent.GetComponent<OnHitColorChange>().OnHit();
        }
        
        Destroy(gameObject, 0.05f);
    }
    public void SetParent(GameObject _parent)
    {
        parent = _parent;
    }
}
