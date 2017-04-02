using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour {

    public int id;
    public string name;
    public string client;
    public string description;
    public string rewardType;
    public int[] rewardParameter;
    public int[] objective;
    public int[] objectiveQuantity;
    public float timeLimit;
    public bool isMainQuest;
    public bool isFailed;
    public int[] subQuests;

    public void StartTimer()
    {
        StartCoroutine(timerTick());
    }

    public void StopTimer()
    {

    }

    public void OnFailure()
    {

    }

    public void OnSuccess()
    {
        DeliverRewards();
    }

    public void DeliverRewards()
    {

    }

    public bool CheckForCompletion()
    {
        return false;
    }

    private IEnumerator timerTick()
    {
        while(true)
        {
            timeLimit--;
            if (timeLimit <= 0)
            {
                OnFailure();
                break;
            }
            yield return new WaitForSeconds(1);
        }
    }
}
