using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionMenuClick : MonoBehaviour
{
    private static int nbPause = 0;
    private static bool lockCursor;


    public static bool isPaused()
    {
        return (nbPause > 0);
    }

    // Use this for initialization
    void Start()
    {

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
        StartCoroutine(PlaySoundAndLoadScene());
        SceneManager.LoadSceneAsync("Main Menu", LoadSceneMode.Single);
    }

    /// <summary>
    /// Use when the user open the in game menu. 
    /// Open the menu, pause the game. Unlock the cursor.
    /// </summary>
    public void OnClickMenu()
    {
        if (gameObject.activeInHierarchy)
        {
            //The Menu is open, so we want to close it
            OptionMenuClick.UnPauseGame();
            gameObject.SetActive(false);
        }
        else
        {
            //The Menu is close, so we want to open it
            gameObject.SetActive(true);
            OptionMenuClick.PauseGame();
        }
        //TODO : Pause game, unlock cursor
    }

    /// <summary>
    /// Stantard procedur for paussing the game
    /// unLock the cursor and set timeScale to 0 (effectively pause all update)
    /// </summary>
    static public void PauseGame()
    {
        nbPause += 1;
        if (nbPause > 0)
        {
            if(nbPause == 1)
            {
                lockCursor = Cursor.visible;
            }
            Time.timeScale = 0;
            Cursor.visible = true;
        }
    }

    /// <summary>
    /// Stantard procedure for unpaussing the game
    /// Lock cursor and set timeScale to 1
    /// </summary>
    static public void UnPauseGame()
    {
        nbPause -= 1;
        if (nbPause <= 0)
        {
            Time.timeScale = 1;
            Cursor.visible = lockCursor;
            nbPause = 0;
        }
    }
    /// <summary>
    /// Use when the user clik on the Quit menu button
    /// </summary>
    public void OnQuitGame()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        Application.Quit();
    }


    IEnumerator PlaySoundAndLoadScene()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);

        SceneManager.LoadScene("Main Menu");

    }
    
}
