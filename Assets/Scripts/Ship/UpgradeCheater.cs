using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeCheater : MonoBehaviour {

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Keypad1)) || 
            Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.Keypad1))
        {
            Debug.Log("HEALTH CODE ACTIVATED");
            GameObject.Find("Stats").GetComponent<ShipStats>().HealthStat = 5;
        }
        else if ((Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Keypad2)) ||
            Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.Keypad2))
        {
            Debug.Log("ARMOR CODE ACTIVATED");
            GameObject.Find("Stats").GetComponent<ShipStats>().ArmorStat = 5;
        }
        else if ((Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Keypad3)) ||
            Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.Keypad3))
        {
            Debug.Log("DAMAGE CODE ACTIVATED");
            GameObject.Find("Stats").GetComponent<ShipStats>().DamageStat = 5;
        }
        else if ((Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Keypad4)) ||
            Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.Keypad4))
        {
            Debug.Log("FIRE RATE CODE ACTIVATED");
            GameObject.Find("Stats").GetComponent<ShipStats>().FireRateStat = 5;
        }
        else if ((Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Keypad5)) ||
            Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.Keypad5))
        {
            Debug.Log("TOP SPEED CODE ACTIVATED");
            GameObject.Find("Stats").GetComponent<ShipStats>().TopSpeedStat = 5;
        }
        else if ((Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Keypad6)) ||
            Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.Keypad6))
        {
            Debug.Log("HANDLING CODE ACTIVATED");
            GameObject.Find("Stats").GetComponent<ShipStats>().HandlingStat = 5;
        }
    }
}
