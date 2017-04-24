using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HangarButton : MonoBehaviour
{
    public void Click()
    {
        if (OptionMenuClick.isPaused() == false)
        {
            SceneManager.LoadSceneAsync("Hangar", LoadSceneMode.Single);
        }
    }
}
