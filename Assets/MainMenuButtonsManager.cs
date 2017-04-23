using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonsManager : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickButton(string sceneName) {
        StartCoroutine(PlaySoundAndLoadScene(sceneName));
    }


    IEnumerator PlaySoundAndLoadScene(string sceneName)
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
        
        if (sceneName != null)
        {
            if (sceneName == "Quit")
            {
                Application.Quit();
            }
            else
            {
                SceneManager.LoadScene(sceneName);
            }
        }

    }


}
