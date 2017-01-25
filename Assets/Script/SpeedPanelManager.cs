using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedPanelManager : MonoBehaviour
{

    public GameObject ship;
    private Rigidbody shipRigibody;

    public float maxSpeed;
    private float _currentSpeed = 0;

    /// <summary>
    /// CurrentSpeed for the speed panel. It a view of the speed of the ship.
    /// Get : get the speed
    /// Set : Change the speed, update the slider and the differents marks.
    /// </summary>
    public float currentSpeed
    {
        get
        {
            return _currentSpeed;
        }
        set
        {
            _currentSpeed = value;
            slider.value = currentSpeed;

            //Update mark if current speed break speed limits
            if (_currentSpeed > maxSpeed)
            {
                slider.maxValue = _currentSpeed;
                mark100.transform.Find("Text").GetComponent<Text>().text = (_currentSpeed).ToString();
            }
            else if (_currentSpeed < -(maxSpeed * 1 / 3))
            {
                slider.minValue = _currentSpeed;
                markNega.transform.Find("Text").GetComponent<Text>().text = (_currentSpeed).ToString(); ;
            }
            else
            {
                //When in speeds limits, reset the marks
                slider.maxValue = maxSpeed;
                slider.minValue = -(maxSpeed / 3);
                mark100.transform.Find("Text").GetComponent<Text>().text = (maxSpeed).ToString();
            }
        }
    }



    private GameObject mark100;
    private GameObject mark66;
    private GameObject mark33;
    private GameObject mark0;
    private GameObject markNega;
    private Slider slider;

    // Use this for initialization
    void Start()
    {
        mark100 = transform.Find(">100%Mark").gameObject;
        mark66 = transform.Find("66%Mark").gameObject;
        mark33 = transform.Find("33%Mark").gameObject;
        mark0 = transform.Find("0Mark").gameObject;
        markNega = transform.Find("<-33%Mark").gameObject;

        slider = transform.Find("Slider").gameObject.GetComponent<Slider>();
        shipRigibody = ship.GetComponentInChildren<Rigidbody>();

        mark100.transform.Find("Text").GetComponent<Text>().text = (maxSpeed).ToString();
        mark66.transform.Find("Text").GetComponent<Text>().text = (maxSpeed * 2 / 3).ToString();
        mark33.transform.Find("Text").GetComponent<Text>().text = (maxSpeed / 3).ToString();
        mark0.transform.Find("Text").GetComponent<Text>().text = "0";
        markNega.transform.Find("Text").GetComponent<Text>().text = "-" + (maxSpeed * 1 / 3).ToString();

        slider.maxValue = maxSpeed;
        slider.minValue = -(maxSpeed / 3);
        slider.value = currentSpeed;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        //Project the ship velocity on his heading vector to get heading velocity.
        currentSpeed = Vector3.Project(shipRigibody.velocity, shipRigibody.gameObject.transform.forward).sqrMagnitude;

    }
}
