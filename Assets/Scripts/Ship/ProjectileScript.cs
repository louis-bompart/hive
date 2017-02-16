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
            entity.gameObject.GetComponent<AsteroidsDesintegration>().health -= 5;
            Debug.Log("Asteroide touche.");
            Debug.Log(entity.gameObject.GetComponent<AsteroidsDesintegration>().health);
            Destroy(gameObject);
    }
}
