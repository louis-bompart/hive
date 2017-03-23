using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MainThrust = 5.0f;
    public float AuxThrust = 2.5f;
    public float Torque = 2.5f;

    private float drag = 0.0f;
    private float angDrag = 0.0f;

    public bool isYawInverted = false;
    public bool isPitchInverted = true;
    public bool isRollInverted = true;

    public float deadZoneX = 0.15f;
    public float deadZoneY = 0.15f;

    public bool showCursor = false;

    public EnginesAnimation engineAnimation;

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        engineAnimation = GetComponentInChildren<EnginesAnimation>();
        rb = GetComponent<Rigidbody>();
        Cursor.visible = showCursor;
        drag = rb.drag;
        angDrag = rb.angularDrag;
    }

    // Update is called once per frame
    void Update()
    {
        HandleFAInput();
    }
    
    void HandleFAInput()
    {
        if(Input.GetAxis("Flight Assist") > 0)
        {
            rb.drag = Mathf.Abs(rb.drag - drag);
            rb.angularDrag = Mathf.Abs(rb.angularDrag - angDrag);
        }
    }

    void FixedUpdate()
    {
        Vector3 acceleration = ComputeThrusts();
        Vector3 torque = ComputeTorques();

        rb.AddRelativeForce(acceleration, ForceMode.Acceleration);
        rb.AddRelativeTorque(torque, ForceMode.Acceleration);

        if (Input.GetAxis("Fire1")>0)
        {
            WeaponSelector temp = gameObject.GetComponent<WeaponSelector>();
            if (temp != null)
            {
                temp.weapons[temp.currentWeapon].BroadcastMessage("OnFire");
            }
           
        }
    }

    /// <summary>
    /// Handle inputs for player's ship orientation
    /// </summary>
    /// <returns>The requested torque</returns>
    private Vector3 ComputeTorques()
    {
        Vector3 torque = Vector3.zero;
        // TODO: Reverse w/ aux thrust

        torque += Vector3.forward * Input.GetAxis("Roll") * Torque * (isRollInverted ? -1 : 1);
        Vector3 mouse = GetMouse();
        torque += Vector3.up * mouse.x * Torque * (isYawInverted ? -1 : 1);
        torque += Vector3.right * mouse.y * Torque * (isPitchInverted ? -1 : 1);
        return torque;
    }

    /// <summary>
    /// Compute the relative position of the mouse w/ the center and it's dead zone as ref.
    /// </summary>
    /// <returns>A vector3 w/ x for the width, y for the height and z as nothing</returns>
    private Vector3 GetMouse()
    {
        Vector3 mousePosition = Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0);
        //If mousePosition.x is in the deadzone then consider it to be at 0;
        mousePosition.x = Mathf.Abs(mousePosition.x) > deadZoneX*Screen.width/2 ? mousePosition.x : 0;
        //Raw pixel value to percent ([0,1])
        mousePosition.x /= (Screen.width / 2);
        //Same for mousePosition.y
        mousePosition.y = Mathf.Abs(mousePosition.y) > deadZoneY*Screen.height/2 ? mousePosition.y : 0;
        mousePosition.y /= (Screen.height / 2);
        return mousePosition;
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
        engineAnimation.UpdateThrottle(Vector3.Project(acceleration,Vector3.forward).magnitude / MainThrust +0.11f);
        return acceleration;
    }
}
