using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLogView : MonoBehaviour
{

    private QuestSlot[] qslots;
    private QuestLogModel qlogmodel;


    private void Awake()
    {
        qlogmodel = GetComponent<QuestLogModel>();
        qslots = GetComponentsInChildren<QuestSlot>(true);
    }

    private void Start()
    {
        LoadQuestLog();
    }

    public void LoadQuestLog()
    {
        int i = 0;
        foreach(QuestSlot qslot in qslots)
        {
            qslot.quest = new Quest();
            qslot.DisplayNoQuest();
        }
        foreach (Quest q in qlogmodel.questlog.Keys)
        {
            qslots[i].quest = q;
            qslots[i].DisplayQuestName();
            i++;
        }
        for (i = 0; i < qslots.Length; i++)
        {
            if (qslots[i].quest.ID == -1)
            {
                qslots[i].DisplayNoQuest();
            }
            qslots[i].DisplayValidateButton();
        }
    }
}