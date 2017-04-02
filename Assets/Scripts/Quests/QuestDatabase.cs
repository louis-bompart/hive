using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestDatabase{

    public List<Quest> database = new List<Quest>();
    private Dictionary<int, Quest> databaseIndexed;
    private static QuestDatabase instance;

    private QuestDatabase(TextAsset questDatabaseJson)
    {
        instance = JsonUtility.FromJson<QuestDatabase>(questDatabaseJson.text);
        instance.databaseIndexed = new Dictionary<int, Quest>();
        foreach(Quest q in instance.database)
        {
            instance.databaseIndexed.Add(q.id, q);
        }
    }

    public Quest FetchQuestByID(int id)
    {
        Quest quest = null;
        databaseIndexed.TryGetValue(id, out quest);
        return quest;
    }

    public static QuestDatabase Instance(TextAsset json)
    {
        if(instance == null)
        {
            new QuestDatabase(json);
        }
        return instance;
    }
}
