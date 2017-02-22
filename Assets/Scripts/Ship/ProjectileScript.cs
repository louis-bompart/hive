using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider entity)
    {      
        Entity temp = entity.GetComponentInParent<Entity>();
        if(temp != null)
        {
            temp.takeDammage(10);
        }
        
        Destroy(gameObject);
    }
}
