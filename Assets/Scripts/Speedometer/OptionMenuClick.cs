using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenuClick : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Save the progression. 
    /// TODO
    /// </summary>
    public void OnSave()
    {
        //TODO
    }

    /// <summary>
    /// Return to the main menu
    /// </summary>
    public void OnReturnMainMenu()
    {
        //TODO
    }

    /// <summary>
    /// Use when the user open the in game menu. 
    /// Open the menu, pause the game. Unlock the cursor.
    /// </summary>
    public void OnLaunchMenu()
    {
        gameObject.SetActive(true);
        //TODO : Pause game, unlock cursor
    }

    /// <summary>
    /// Use when the user clik on the resume menu button
    /// Resume the game, close the menu
    /// </summary>
    public void OnResumeGame()
    {
        gameObject.SetActive(false);
        //TODO : UnpauseGame, lock cursor
    }
    /// <summary>
    /// Use when the user clik on the Quit menu button
    /// </summary>
    public void OnQuitGame()
    {
        Application.Quit();
    }
}
