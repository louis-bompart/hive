using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BridgeButton : MonoBehaviour
{

    public void Click()
    {
        if (OptionMenuClick.isPaused() == false)
        {
            SceneManager.LoadSceneAsync("Bridge", LoadSceneMode.Single);
        }
    }
}
