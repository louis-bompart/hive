using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MainThrust = 5.0f;
    public float AuxThrust = 2.5f;
    public float Torque = 2.5f;

    public bool isYawInverted = false;
    public bool isPitchInverted = true;
    public bool isRollInverted = true;

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 acceleration = ComputeThrusts();
        Vector3 torque = ComputeTorques();

        rb.AddRelativeForce(acceleration, ForceMode.Acceleration);
        rb.AddRelativeTorque(torque, ForceMode.Acceleration);
    }

    /// <summary>
    /// Handle inputs for player's ship orientation
    /// </summary>
    /// <returns>The reauested torque</returns>
    private Vector3 ComputeTorques()
    {
        Vector3 torque = Vector3.zero;
        // TODO: Reverse w/ aux thrust

        torque += Vector3.forward * Input.GetAxis("Roll") * Torque * (isRollInverted ? -1 : 1);
        torque += Vector3.up * Input.GetAxis("Yaw") * Torque * (isYawInverted ? -1 : 1);
        torque += Vector3.right * Input.GetAxis("Pitch") * Torque * (isPitchInverted ? -1 : 1);
        return torque;
    }

    /// <summary>
    /// Handle inputs for player's ship acceleration
    /// </summary>
    /// <returns>The requested acceleration</returns>
    private Vector3 ComputeThrusts()
    {
        Vector3 acceleration = Vector3.zero;
        acceleration += Vector3.forward * Input.GetAxis("Thrust") * MainThrust;
        acceleration += Vector3.up * Input.GetAxis("Vertical") * AuxThrust;
        acceleration += Vector3.right * Input.GetAxis("Horizontal") * AuxThrust;
        return acceleration;
    }
}
