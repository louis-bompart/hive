using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsMovement : MonoBehaviour
{

    private Rigidbody rb;


    /// <summary>
    /// The minimum and maximum rotation speed allowed for an asteroid.
    /// </summary>
    public int minrSpeed = 1;
    public int maxrSpeed = 8;

    /// <summary>
    /// rxSpeed : rotation speed around x axis.
    /// rySpeed : rotation speed around y axis.
    /// rzSpeed : rotation speed around z axis.
    /// </summary>
    private int rxSpeed;
    private int rySpeed;
    private int rzSpeed;

    /// <summary>
    /// The minimum and maximum movement speed allowed for an asteroid.
    /// </summary>
    public int minmSpeed = 10;
    public int maxmSpeed = 200;

    /// <summary>
    /// mxSpeed : movement speed on x axis.
    /// mySpeed : movement speed on y axis.
    /// mzSpeed : movement speed on z axis.
    /// </summary>
    private int mxSpeed = 0;
    private int mySpeed = 0;
    private int mzSpeed = 0;

    /// <summary>
    /// Attribute the rotation and movement speed for the asteroid.
    /// Apply a force to the asteroid.
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        mxSpeed = Random.Range(minmSpeed, maxmSpeed);
        mySpeed = Random.Range(minmSpeed, maxmSpeed);
        mzSpeed = Random.Range(minmSpeed, maxmSpeed);

        rxSpeed = Random.Range(minrSpeed, maxrSpeed);
        rySpeed = Random.Range(minrSpeed, maxrSpeed);
        rzSpeed = Random.Range(minrSpeed, maxrSpeed);

        Vector3 movement = new Vector3(mxSpeed, mySpeed, mzSpeed);
        rb.AddForce(movement);

        Vector3 rotation = new Vector3(rxSpeed, rySpeed, rzSpeed);
        rb.AddTorque(rotation);
    }

    /// <summary>
    /// Rotates the asteroid.
    /// </summary>
    void FixedUpdate() { }
}
