using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestProgress : MonoBehaviour {

    public int questProgress;
    public List<int> CompletedQuests;
    public int questTimer;

    private void Awake()
    {
        if (CompletedQuests == null)
        {
            CompletedQuests = new List<int>();
        }
    }

    public void StartTimer()
    {
        GameObject.Find("QuestTimer").GetComponentInChildren<Slider>().maxValue = questTimer;
        StartCoroutine(TimerTick());
    }
    
    private IEnumerator TimerTick()
    {    
        questTimer--;
        GameObject.Find("QuestTimer").GetComponentInChildren<Slider>().value = questTimer;
        yield return new WaitForSeconds(1);
        if(questTimer <= 0 && questTimer != -1000)
        {
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
        StartCoroutine(TimerTick());
    }
    
    public void StopTimer()
    {
        StopAllCoroutines();
    }
}
