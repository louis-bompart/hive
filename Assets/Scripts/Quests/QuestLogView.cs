using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestLogView : MonoBehaviour {

    public QuestLogModel questlogmodel;
    public Quest[] quests;

    void Awake()
    {
        questlogmodel = null;
        questlogmodel = GameObject.Find("QuestLog").GetComponent<QuestLogModel>();
    }

    private void Start()
    {
        LoadAllQuests();
    }

    public void LoadAllQuests()
    {
        Dictionary<Quest, int> questLogDico = questlogmodel.QuestLog;
        foreach(Quest quest in quests)
    }
}
