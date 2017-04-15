using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLogController : MonoBehaviour {

    public TextAsset questJSON;

    private QuestDatabase database;

    private QuestLogModel qlogmodel;
    private QuestLogView qlogview;
    public QuestProgress qprogress;

    void Awake()
    {
        database = QuestDatabase.Instance(questJSON);
        qlogmodel = GetComponent<QuestLogModel>();
        qlogview = GetComponent<QuestLogView>();
        qprogress = GameObject.Find("Data").GetComponentInChildren<QuestProgress>();
    }

    private void Start()
    {
        UpdateQuestLog();
    }

    private void Update()
    {
        if(qlogmodel == null)
        {
            Debug.LogWarning("Quest log lost. Trying to recover...");
            qlogmodel = GameObject.Find("QuestLogModel").GetComponent<QuestLogModel>();
            if (qlogmodel != null)
                Debug.Log("We're good, Quest log recovered !");
            else
                Debug.LogError("Quest log recovery failed. You have no purpose. Just like Ruf.");
        }
    }

    public void UpdateQuestLog()
    {
        qlogmodel.questlog = new Dictionary<Quest, int>();
        Quest mainquest = database.FetchQuestByID(qprogress.questProgress);
        if(qprogress.questTimer == -1000 || qprogress.questTimer == 0)
        {
            qprogress.questTimer = mainquest.timeLimit;
        }
        qlogmodel.questlog.Add(mainquest, mainquest.ID);
        if(mainquest.subQuests != "")
        {
            foreach (int subquestID in mainquest.SubQuestsList)
            {
                int sqid = subquestID;
                if (qprogress.CompletedQuests.Find(i => i == sqid) == 0)
                {
                    qlogmodel.questlog.Add(database.FetchQuestByID(subquestID), subquestID);
                }
            }
        }      
        qlogview.LoadQuestLog();
    }
}
