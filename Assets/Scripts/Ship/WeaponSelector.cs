using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
{

    public int currentWeapon;
    private int nbWeapons;
    public GameObject[] weapons;

    // Use this for initialization
    void Start()
    {
        nbWeapons = 2;
        currentWeapon = 0;
        for (int i = 0; i < nbWeapons; i++) {
            weapons[i].gameObject.SetActive(false);

        }
        weapons[currentWeapon].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

       

        for (int i = 0; i < nbWeapons; i++)
        {
            int j = i + 1;
            if (Input.GetKeyDown("" + j))
            {
                currentWeapon = i;
                SwitchWeapon(currentWeapon);
                Debug.Log("arme équipée : " + i);
            }
        }
        

    }

    void SwitchWeapon(int index) {
        for (int i = 0; i < nbWeapons; i++) {
            weapons[i].gameObject.SetActive((i == index));
        }
    }
}
