using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLog : MonoBehaviour {

    public TextAsset questJSON;

    public int QuestProgress;

    public GameObject QuestView;

    public List<Quest> quests;
    private QuestDatabase database;

    private void Awake()
    {
        database = QuestDatabase.Instance(questJSON);
        QuestView = GameObject.Find("QuestView").GetComponent<QuestView>();
    }

    private void Start()
    {
        QuestProgress = GameObject.Find("Data").GetComponent<QuestInfo>().questProgress;
        quests = LoadQuests(QuestProgress);
    }

    public List<Quest> LoadQuests(int QuestProgress)
    {
        quests = new List<Quest>();
        Quest currentMainQuest = database.FetchQuestByID(QuestProgress);
        quests.Add(currentMainQuest);
        foreach (int subquestId in currentMainQuest.subQuests)
        {
            Quest questToAdd = database.FetchQuestByID(subquestId);
            quests.Add(questToAdd);
        }
        return quests;
    }

    public void StartTimer()
    {
        foreach (Quest q in quests)
        {
            q.StartTimer();
        }
    }

    public void StopTimer()
    {
        foreach(Quest q in quests)
        {
            q.StopTimer();
        }
    }
}
