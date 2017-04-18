using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLogView : MonoBehaviour
{

    public QuestSlot Mainqslot;
    public QuestSlot[] Subqslots;
    private QuestLogModel qlogmodel;


    private void Awake()
    {
        qlogmodel = GetComponent<QuestLogModel>();
    }

    private void Start()
    {
        LoadQuestLog();
    }

    public void LoadQuestLog()
    {
        int i = 0;
        Mainqslot.quest = new Quest();
        foreach(QuestSlot qslot in Subqslots)
        {
            qslot.quest = new Quest();
            qslot.DisplayNoQuest();
        }
        foreach(Quest q in qlogmodel.questlog.Keys)
        {
            if(q.isMainQuest)
            {
                Mainqslot.quest = q;
                Mainqslot.DisplayQuestName();
                break;
            }
        }
        foreach (Quest q in qlogmodel.questlog.Keys)
        {
            if (!q.isMainQuest)
            {
                Subqslots[i].quest = q;
                Subqslots[i].DisplayQuestName();
                i++;
            }
        }
        Mainqslot.DisplayValidateButton();
        for (i = 0; i < Subqslots.Length; i++)
        {
            if (Subqslots[i].quest.ID == -1)
            {
                Subqslots[i].DisplayNoQuest();
            }
            Subqslots[i].DisplayValidateButton();
        }
    }
}