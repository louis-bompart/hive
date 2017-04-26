using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BaseAccess : MonoBehaviour
{
    public string sceneToAccessName;
    public Text buttonPrompt;

    private void OnTriggerEnter(Collider other)
    {
        buttonPrompt.gameObject.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetAxis("Submit") > 0 && OptionMenuClick.isPaused() == false)
        {
            Cursor.visible = true;
            GameObject.Find("Data").GetComponentInChildren<QuestProgress>().StopTimer();
            SceneManager.LoadSceneAsync(sceneToAccessName, LoadSceneMode.Single);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        buttonPrompt.gameObject.SetActive(false);
    }
}
