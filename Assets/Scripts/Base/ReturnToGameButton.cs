using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToGameButton : MonoBehaviour {

	public void Click()
    {
        SceneManager.LoadScene("UpgradeTest", LoadSceneMode.Single);
    }
}
