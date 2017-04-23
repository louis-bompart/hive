using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToGameButton : MonoBehaviour
{
    public void Click(string sceneToLoad)
    {
        FindObjectOfType<ShipStats>().origin = ShipStats.Origin.Base;
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    }
}
