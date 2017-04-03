using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLogController : MonoBehaviour {

    public TextAsset questJSON;

    private QuestDatabase database;

    void Awake()
    {
        database = QuestDatabase.Instance(questJSON);
    }

    private void Start()
    {
        Debug.Log(database.FetchQuestByID(1).QuestName);
        Debug.Log(database.FetchQuestByID(2).ObjectiveList.Count);
    }
}
