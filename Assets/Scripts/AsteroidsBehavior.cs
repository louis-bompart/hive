using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsBehavior : MonoBehaviour {

	private Rigidbody rb;

	private int minrSpeed = 1;
	private int maxrSpeed = 8;
	private int rxSpeed;
	private int rySpeed;
	private int rzSpeed;

	private int minmSpeed = 1;
	private int maxmSpeed = 20;
	private int mxSpeed;
	private int mySpeed;
	private int mzSpeed;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody>();

		Vector3 movement = new Vector3 (mxSpeed, mySpeed, mzSpeed);
		rb.AddForce (movement);

		mxSpeed = Random.Range (minmSpeed, maxmSpeed);
		mySpeed = Random.Range (minmSpeed, maxmSpeed);
		mzSpeed = Random.Range (minmSpeed, maxmSpeed);

		rxSpeed = Random.Range (minrSpeed, maxrSpeed);
		rySpeed = Random.Range (minrSpeed, maxrSpeed);
		rzSpeed = Random.Range (minrSpeed, maxrSpeed);


	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate (new Vector3 (rxSpeed, rySpeed, rzSpeed) * Time.deltaTime);

	}
}
