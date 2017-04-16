using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        StartCoroutine(TimerTick());
    }
    
    private IEnumerator TimerTick()
    {
    
        questTimer--;
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
