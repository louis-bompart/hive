using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

    private void OnTriggerEnter(Collider other)
    {
        POI system = other.gameObject.GetComponent<POI>();
        if (system!=null)
        {
            system.isAccessible = true;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
