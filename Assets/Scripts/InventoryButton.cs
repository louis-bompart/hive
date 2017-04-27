using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour {

    public GameObject inv;

    public void onClick()
    {
        if(inv.activeSelf == false)
        {
            OptionMenuClick.PauseGame();
            inv.SetActive(true);
        }
        else
        {
            OptionMenuClick.UnPauseGame();
            inv.SetActive(false);
        }
        

    }
}
