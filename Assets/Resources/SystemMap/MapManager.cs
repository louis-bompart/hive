using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MapManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Cursor.visible = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void LoadScene(string sceneToLoad)
    {
        Cursor.visible = false;
        SceneManager.LoadSceneAsync(sceneToLoad,LoadSceneMode.Single);
    }


}
