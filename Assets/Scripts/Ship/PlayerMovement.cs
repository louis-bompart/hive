using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public float mainThrust;
    public float auxThrust = 2.5f;
    public float torque = 2.5f;

    //private float drag = 15.0f;
    //private float angDrag = 0.0f;

    public bool isYawInverted = false;
    public bool isPitchInverted = true;
    public bool isRollInverted = true;

    public float deadZoneX = 0.15f;
    public float deadZoneY = 0.15f;

    public bool showCursor = false;
    public float velocity;
    public EnginesAnimation engineAnimation;

    private Rigidbody rb;
    public ShipStats stats;
    public float warpTime;
    private float actualLoading;
    private Player player;
    public float terminalVelocity;

    public GameObject warpGauge;
    private Slider warpSlider;

    // Use this for initialization
    void Start()
    {
        GameObject.Find("Data").GetComponentInChildren<QuestProgress>().StartTimer();
        engineAnimation = GetComponentInChildren<EnginesAnimation>();
        rb = GetComponent<Rigidbody>();
        stats = GameObject.Find("Stats").GetComponent<ShipStats>();
        player = GetComponent<Player>();
        Cursor.visible = showCursor;
        //drag = rb.drag;

        UpdateSpeedAndAcceleration();

        if (warpGauge == null)
        {
            warpGauge = GameObject.Find("WarpGauge");
        }

        if (warpGauge != null)
        {
            warpSlider = warpGauge.GetComponentInChildren<Slider>();
            if (warpSlider == null)
            {
                Debug.Log("Couldn't find warp slider");
            }
            else
            {
                Debug.Log("warpGauge gameObject empty");
            }
        }
    }

    private void UpdateSpeedAndAcceleration()
    {
        terminalVelocity = 50.0f * (stats.topSpeed + 1);
        mainThrust = terminalVelocity / (3 * rb.mass);
        //rb.angularDrag = 7 - stats.HandlingStat;

        float idealDrag = mainThrust / terminalVelocity;

        rb.drag = idealDrag / (idealDrag * Time.fixedDeltaTime + 1);
    }

    // Update is called once per frame
    void Update()
    {
        HandleWarpDrive();
        UpdateSpeedAndAcceleration();
    }

    void HandleWarpDrive()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            warpGauge.SetActive(true);
            actualLoading += Time.deltaTime;
            warpSlider.value = (actualLoading / warpTime);
            if (actualLoading >= warpTime)
            {
                SceneManager.LoadSceneAsync("SystemMap", LoadSceneMode.Single);
            }
        }
        else
        {
            actualLoading = 0;
            warpGauge.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        velocity = rb.velocity.sqrMagnitude;
        Vector3 acceleration = ComputeThrusts();
        Vector3 torque = ComputeTorques();
        //if (rb.velocity.magnitude > (stats.TopSpeedStat +1)* 100)
        //{
        //    acceleration = Vector3.zero;
        //}
        acceleration = ModularCap(acceleration);
        rb.AddRelativeForce(acceleration, ForceMode.Acceleration);
        rb.AddRelativeTorque(torque, ForceMode.Acceleration);

        if (Input.GetAxis("Fire1") > 0)
        {
            WeaponSelector temp = gameObject.GetComponent<WeaponSelector>();
            if (temp != null)
            {
                temp.weapons[temp.currentWeapon].SendMessage("OnFire");
            }

        }
    }

    private Vector3 ModularCap(Vector3 acceleration)
    {
        float accelerationRate = 0.0f;
        float velocity = rb.velocity.sqrMagnitude;
        float v = velocity / terminalVelocity;
        if (velocity < terminalVelocity * 0.3)
        {
            accelerationRate = 0.5f * Mathf.Pow(v, 3) + Mathf.Pow(v, 2) + 0.1f;
        }
        else if (velocity < terminalVelocity * 0.4)
        {
            accelerationRate = 0.2f * (1f - Mathf.Cos((800f * Mathf.PI / 119f) * 0.3f - 281f * Mathf.PI / 119f - Mathf.PI / 2f) + Mathf.Cos(Mathf.Cos((800f * Mathf.PI / 119f) * v - 281f * Mathf.PI / 119f - Mathf.PI / 2f) * 0.2f));
        }
        else
        {
            accelerationRate = -29.5521f * Mathf.Pow(v, 3) + 53.3271f * Mathf.Pow(v, 2) + -28.8817f * v + 5.10667f;
        }
        return Vector3.ClampMagnitude(acceleration, accelerationRate * mainThrust);
    }

    /// <summary>
    /// Handle inputs for player's ship orientation
    /// </summary>
    /// <returns>The requested torque</returns>
    private Vector3 ComputeTorques()
    {
        Vector3 torque = Vector3.zero;
        // TODO: Reverse w/ aux thrust

        torque += Vector3.forward * Input.GetAxis("Roll") * this.torque * (isRollInverted ? -1 : 1);
        Vector3 mouse = GetMouse();
        torque += Vector3.up * mouse.x * this.torque * (isYawInverted ? -1 : 1);
        torque += Vector3.right * mouse.y * this.torque * (isPitchInverted ? -1 : 1);
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
        mousePosition.x = Mathf.Abs(mousePosition.x) > deadZoneX * Screen.width / 2 ? mousePosition.x : 0;
        //Raw pixel value to percent ([0,1])
        mousePosition.x /= (Screen.width / 2);
        //Same for mousePosition.y
        mousePosition.y = Mathf.Abs(mousePosition.y) > deadZoneY * Screen.height / 2 ? mousePosition.y : 0;
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
        acceleration += Vector3.forward * Input.GetAxis("Thrust") * mainThrust;
        acceleration += Vector3.up * Input.GetAxis("Vertical") * auxThrust;
        acceleration += Vector3.right * Input.GetAxis("Horizontal") * auxThrust;
        engineAnimation.UpdateThrottle(Vector3.Project(acceleration, Vector3.forward).magnitude / mainThrust + 0.11f);
        Vector3.ClampMagnitude(acceleration, mainThrust);
        return acceleration;
    }

    //Determines severity of a collision, based on ship's velocity, and inflicts damage to the player depending on that velocity.
    private void OnCollisionEnter(Collision collision)
    {
        int velocity = (int)Mathf.Round(rb.velocity.sqrMagnitude);
        int severity = 0;
        if (velocity < 50)
        {
            severity = 0;
        }
        else if (velocity >= 50 && velocity < 100)
        {
            severity = 1;
        }
        else if (velocity >= 100 && velocity < 200)
        {
            severity = 2;
        }
        else if (velocity >= 200 && velocity < 325)
        {
            severity = 3;
        }
        else if (velocity >= 325)
        {
            severity = 4;
        }
        switch (severity)
        {
            case 0:
                player.TakeArmorDamage(5, stats.armorStat);
                Debug.Log("Damage taken : 5.");
                break;
            case 1:
                player.TakeArmorDamage(10, stats.armorStat);
                Debug.Log("Damage taken : 10.");
                break;
            case 2:
                player.TakeArmorDamage(35, stats.armorStat);
                Debug.Log("Damage taken : 35.");
                break;
            case 3:
                player.TakeArmorDamage(90, stats.armorStat);
                Debug.Log("Damage taken : 90.");
                break;
            case 4:
                player.TakeArmorDamage(150, stats.armorStat);
                Debug.Log("Damage taken : 150.");
                break;
            default:
                break;
        }
    }
}

