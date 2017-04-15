using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestSlot : MonoBehaviour {

    public Quest quest;
    public GameObject Validate;

    public void DisplayValidateButton()
    {
        if(CheckForCompletion())
        {
            Validate.SetActive(true);
        }
        else
        {
            Validate.SetActive(false);
        }
    }
    public void DisplayQuestName()
    {
        GetComponentInChildren<Text>().text = quest.QuestName;
    }

    public void DisplayNoQuest()
    {
        GetComponentInChildren<Text>().text = "No subquest";
    }

    public void StartTimer()
    {
        StartCoroutine(TimerTick());
    }

    private IEnumerator TimerTick()
    {
        while(true)
        {
            quest.TimeLimit--;
            yield return new  WaitForSeconds(1);
            if(quest.TimeLimit <= 0)
            {
                OnFailure();
            }
        }
    }

    public void StopTimer()
    {
        StopCoroutine(TimerTick());
    }

    public bool CheckForCompletion()
    {
        if (quest.ID != -1)
        {
            InventoryController invctrl = GameObject.Find("ShipInventoryLarge").GetComponent<InventoryController>();
            int currentQuantity = 0;
            using (var e1 = quest.ObjectiveList.GetEnumerator())
            using (var e2 = quest.ObjectiveQuantityList.GetEnumerator())
            {
                while (e1.MoveNext() && e2.MoveNext())
                {
                    currentQuantity = invctrl.GetQuantity(e1.Current);
                    if (e2.Current > currentQuantity)
                    {
                        Debug.Log("Pas assez");
                        return false;
                    }
                }
            }
            return true;
        }
        else return false;
    }

    public void OnFailure()
    {
        //condition de game over a mettre ici
    }

    public void OnSuccess()
    {
        InventoryController invctrl = GameObject.Find("ShipInventoryLarge").GetComponent<InventoryController>();
        using (var e1 = quest.ObjectiveList.GetEnumerator())
        using (var e2 = quest.ObjectiveQuantityList.GetEnumerator())
        {
            while (e1.MoveNext() && e2.MoveNext())
            {
                invctrl.RemoveItem(e1.Current, e2.Current);
            }
        }
        GameObject.Find("Data").GetComponentInChildren<QuestProgress>().CompletedQuests.Add(quest.ID);
        GameObject.Find("Data").GetComponentInChildren<QuestProgress>().questTimer = -1000;
        DeliverRewards();
    }

    public void DeliverRewards()
    {
        InventoryController invctrl = GameObject.Find("ShipInventoryLarge").GetComponent<InventoryController>();
        using (var e1 = quest.RewardList.GetEnumerator())
        using (var e2 = quest.RewardQuantityList.GetEnumerator())
        {
            while(e1.MoveNext() && e2.MoveNext())
            {
                invctrl.AddItem(e1.Current, e2.Current);
            }
        }
        if (quest.IsMainQuest)
        {
            GameObject.Find("Data").GetComponentInChildren<QuestProgress>().questProgress++;
        }
        if(quest.Victory == 1)
        {
            SceneManager.LoadSceneAsync("HiveVictory", LoadSceneMode.Single);
        }
        else if(quest.Victory == 2)
        {
            SceneManager.LoadSceneAsync("AIRVictory", LoadSceneMode.Single);
        }
        else if(quest.Victory == 3)
        {
            SceneManager.LoadSceneAsync("SelfVictory", LoadSceneMode.Single);
        }
        GameObject.Find("QuestLog").GetComponent<QuestLogController>().UpdateQuestLog();
    }
}
