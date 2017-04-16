using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class QuestDatabase
{
    public List<Quest> questDatabase = new List<Quest>();
    private Dictionary<int, Quest> questDatabaseIndexed;
    private static QuestDatabase questDatabaseInstance;

    private QuestDatabase(TextAsset questDatabaseJson)
    {
        questDatabaseInstance = JsonUtility.FromJson<QuestDatabase>(questDatabaseJson.text);
        questDatabaseInstance.questDatabaseIndexed = new Dictionary<int, Quest>();
        foreach (Quest quest in questDatabaseInstance.questDatabase)
        {

            foreach (string s in quest.objectives.Split(','))
            {
                int x = 0;
                int.TryParse(s, out x);
                quest.ObjectiveList.Add(x);
            }
            foreach (string s in quest.objectiveQuantity.Split(','))
            {
                int x = 0;
                int.TryParse(s, out x);
                quest.ObjectiveQuantityList.Add(x);
            }
            foreach (string s in quest.reward.Split(','))
            {
                int x = 0;
                int.TryParse(s, out x);
                quest.RewardList.Add(x);
            }
            foreach (string s in quest.rewardQuantity.Split(','))
            {
                int x = 0;
                int.TryParse(s, out x);
                quest.RewardQuantityList.Add(x);
            }
            foreach (string s in quest.subQuests.Split(','))
            {
                int x = 0;
                int.TryParse(s, out x);
                quest.SubQuestsList.Add(x);
            }
            questDatabaseInstance.questDatabaseIndexed.Add(quest.ID, quest);
        }
    }

    public Quest FetchQuestByID(int id)
    {
        Quest quest = null;
        questDatabaseIndexed.TryGetValue(id, out quest);
        return quest;
    }

    public static QuestDatabase Instance(TextAsset json)
    {
        if(questDatabaseInstance == null)
        {
            new QuestDatabase(json);
        }
        return questDatabaseInstance;
    }
}
