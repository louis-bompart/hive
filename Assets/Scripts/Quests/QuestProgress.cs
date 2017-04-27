using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestProgress : MonoBehaviour {

    public int questProgress;
    public List<int> CompletedQuests;
    public int questTimer;
    public GameObject questTimeDisplay;

    private void Awake()
    {
        if (CompletedQuests == null)
        {
            CompletedQuests = new List<int>();
        }
    }

    public void StartTimer()
    {
        questTimeDisplay = GameObject.Find("QuestTimeDisplay");
        questTimeDisplay.GetComponent<Text>().text = Mathf.Floor(questTimer/60).ToString("00") + ":" + (questTimer%60).ToString("00");
        StartCoroutine(TimerTick());
    }
    
    private IEnumerator TimerTick()
    {    
        questTimer--;
        if(questTimeDisplay != null)
        {
            questTimeDisplay.GetComponent<Text>().text = Mathf.Floor(questTimer / 60).ToString("00") + ":" + (questTimer % 60).ToString("00");
        }
        
        yield return new WaitForSeconds(1);
        if(questTimer <= 0 && questTimer != -1000)
        {
            SceneManager.LoadSceneAsync("GameOver", LoadSceneMode.Single);
        }
        StartCoroutine(TimerTick());
    }
    
    public void StopTimer()
    {
        StopAllCoroutines();
    }
}
