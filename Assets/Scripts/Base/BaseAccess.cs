using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BaseAccess : MonoBehaviour {

    public Text Button_Prompt;

    private void OnTriggerEnter(Collider other)
    {
        Button_Prompt.gameObject.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetAxis("Submit")>0)
        {
            Cursor.visible = true;
            SceneManager.LoadSceneAsync("Bridge", LoadSceneMode.Single);
        }
    }

    private void OnTriggerExit(Collider other)
    {
         Button_Prompt.gameObject.SetActive(false);
    }
}
