using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {

    public GameObject rotationCenter;
    public Transform cameraTransform;
    private float StartTime;

	// Use this for initialization
	void Start () {
        StartTime = Time.time;
	}

    private void Update()
    {
        if(Time.time - StartTime >= 3.0f)
        cameraTransform.RotateAround(rotationCenter.transform.position, new Vector3(1.0f, 0.0f, 0.0f), 0.5f * Time.deltaTime);
    }
}
