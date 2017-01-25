using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float MainThrust = 5.0f;
    public float AuxThrust = 2.5f;

    public float Torque = 2.5f;

    public bool isYawInverted = false;
    public bool isPitchInverted= true;
    public bool isRollInverted= true;

    private Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 acceleration = Vector3.zero;
        acceleration += Vector3.forward * Input.GetAxis("Thrust") * MainThrust;
        acceleration += Vector3.up * Input.GetAxis("Vertical") * AuxThrust;
        acceleration += Vector3.right * Input.GetAxis("Horizontal") * AuxThrust;

        Vector3 torque = Vector3.zero;
        torque += Vector3.forward * Input.GetAxis("Roll") * Torque * (isRollInverted ? -1 : 1);
        torque += Vector3.up * Input.GetAxis("Yaw") * Torque * (isYawInverted ? -1 : 1);
        torque += Vector3.right * Input.GetAxis("Pitch") * Torque * (isPitchInverted? -1 : 1);

        rb.AddRelativeForce(acceleration, ForceMode.Acceleration);
        rb.AddRelativeTorque(torque, ForceMode.Acceleration);
    }
}
