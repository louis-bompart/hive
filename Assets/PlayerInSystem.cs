using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInSystem : MonoBehaviour {
    float range = 0f;
	// Use this for initialization
	void Start () {
        range = FindObjectOfType<BaseStats>().scanRangeStat;
        transform.localScale = Vector3.one*range;
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
