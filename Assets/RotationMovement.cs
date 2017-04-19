using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMovement : MonoBehaviour {

    public float rotationSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.rotation.Set(transform.rotation.x, transform.rotation.y + rotationSpeed, transform.rotation.z, transform.rotation.w);

        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
    }
}
