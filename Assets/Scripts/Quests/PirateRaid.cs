using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateRaid : MonoBehaviour {

    public GameObject[] pirates;

    int currentQuest;

    void Start()
    {

        int lastRaid = Data.instance.GetComponentInChildren<DataPirateRaidManager>().raidNumber;
        currentQuest = Data.instance.GetComponentInChildren<QuestProgress>().questProgress;

        if(lastRaid<currentQuest)
        {
            launchRaid(currentQuest);
        }
    }


    void launchRaid(int number)
    {
        for(int i = 0;i<number && i < pirates.Length; i++)
        {
            pirates[i].SetActive(true);
        }
    }

    void Update()
    {
        bool testAllDead = true;
        for(int i = 0; i<pirates.Length && testAllDead == true;i++)
        {
            if(pirates[i] != null && pirates[i].activeSelf == true)
            { 
                testAllDead = false;
            }
        }
        if(testAllDead == true)
        {
            Data.instance.GetComponentInChildren<DataPirateRaidManager>().raidNumber = currentQuest;
        }
       
    }
}
