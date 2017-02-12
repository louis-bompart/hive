using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FactoryButton : MonoBehaviour
{

    public void Click()
    {
        SceneManager.LoadScene("Factory", LoadSceneMode.Single);
    }
}
