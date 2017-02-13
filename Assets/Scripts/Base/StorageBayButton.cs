using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StorageBayButton : MonoBehaviour
{

    public void Click()
    {
        SceneManager.LoadScene("StorageBay", LoadSceneMode.Single);
    }
}
