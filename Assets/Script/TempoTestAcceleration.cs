using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoTestAcceleration : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().velocity = new Vector3(100, 0, 0);
	}
}
