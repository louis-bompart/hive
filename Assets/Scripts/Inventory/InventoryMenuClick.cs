using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenuClick : MonoBehaviour {

	// Use this for initialization
	void Start()
	{
		gameObject.SetActive(false);
	}
		


	/// <summary>
	/// Use when the user open the in game inventory. 
	/// </summary>
	public void OnLaunch()
	{
        
		if (gameObject.activeInHierarchy)
        {
            //The inventory is open, so we want to close it
            gameObject.SetActive(false);
            OptionMenuClick.UnPauseGame();
        }
        else
        {
            //The inventory is close, so we want to open it
			gameObject.SetActive (true);
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
