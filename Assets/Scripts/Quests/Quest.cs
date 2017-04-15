using Boo.Lang;
using System;
using UnityEngine;

[System.Serializable]

public class Quest
{
    public int ID
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }
    public string QuestName
    {
        get
        {
            return questName;
        }
        set
        {
            questName = value;
        }
    }
    public string Client
    {
        get
        {
            return client;
        }
        set
        {
            client = value;
        }
    }
    public string Description
    {
        get
        {
            return description;
        }
        set
        {
            description = value;
        }
    }
    public bool IsMainQuest
    {
        get
        {
            return isMainQuest;
        }
        set
        {
            isMainQuest = value;
        }
    }
    public int TimeLimit
    {
        get
        {
            return timeLimit;
        }
        set
        {
            timeLimit = value;
        }
    }
    public string Objectives
    {
        get
        {
            return objectives;
        }
        set
        {
            objectives = value;
        }
    }
    public string ObjectiveQuantity
    {
        get
        {
            return objectiveQuantity;
        }
        set
        {
            objectiveQuantity = value;
        }
    }
    public string Reward
    {
        get
        {
            return reward;
        }
        set
        {
            reward = value;
        }
    }
    public string RewardQuantity
    {
        get
        {
            return rewardQuantity;
        }
        set
        {
            rewardQuantity = value;
        }
    }
    public string SubQuests
    {
        get
        {
            return subQuests;
        }
        set
        {
            subQuests = value;
        }
    }
    public int Victory
    {
        get
        {
            return victory;
        }
        set
        {
            victory = value;
        }
    }
    public List<int> ObjectiveList = new List<int>();
    public List<int> ObjectiveQuantityList = new List<int>();
    public List<int> RewardList = new List<int>();
    public List<int> RewardQuantityList = new List<int>();
    public List<int> SubQuestsList = new List<int>();

    public int id;
    public string questName;
    public string client;
    public string description;
    public bool isMainQuest;
    public int timeLimit;
    public string objectives;
    public string objectiveQuantity;
    public string reward;
    public string rewardQuantity;
    public string subQuests;
    public int victory;

    public Quest(int id, string questName, string client, string description, bool isMainQuest, int timeLimit, 
        string objectives, string objectiveQuantity, string reward, string rewardQuantity, string subQuests, int victory)
    {
        this.ID = id;
        this.QuestName = questName;
        this.Client = client;
        this.Description = description;
        this.IsMainQuest = isMainQuest;
        this.TimeLimit = timeLimit;
        this.Objectives = objectives;
        this.ObjectiveQuantity = objectiveQuantity;
        this.Reward = reward;
        this.RewardQuantity = rewardQuantity;
        this.SubQuests = subQuests;
        this.Victory = victory;
    }

    public Quest()
    {
        this.ID = -1;
    }

    public override bool Equals(object obj)
    {
        return (obj as Quest).ID == this.ID;
    }

    public override int GetHashCode()
    {
        return ID;
    }

}