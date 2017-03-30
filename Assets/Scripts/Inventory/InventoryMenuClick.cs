using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenuClick : MonoBehaviour
{
    public bool isOpenOnStart = false;
    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(isOpenOnStart);
    }

    /// <summary>
    /// Use when the user open the in game inventory. 
    /// </summary>
    public void OnLaunch()
    {
        if (gameObject.activeInHierarchy)
        {
            //The inventory is open, so we want to close it
			//GameObject inv = GameObject.Find ("Inventory");
			Tooltip tooltip = gameObject.transform.parent.gameObject.GetComponentInChildren<Tooltip> ();
			tooltip.Deactivate ();
            gameObject.SetActive(false);
            OptionMenuClick.UnPauseGame();
        }
        else
        {
            //The inventory is close, so we want to open it
            gameObject.SetActive(true);
            OptionMenuClick.PauseGame();
        }
        //TODO : unlock cursor
    }

    /// <summary>
    /// Use when the user clik on the Quit menu button
    /// </summary>
    public void OnQuitGame()
    {
        Application.Quit();
    }
}
