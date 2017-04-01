using System.Collections;
using System.Collections.Generic;
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
    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
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
    public float TimeLimit
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
    public int[] Objective
    {
        get
        {
            return objective;
        }
        set
        {
            objective = value;
        }
    }
    public int[] ObjectiveQuantity
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
    public int[] Rewards
    {
        get
        {
            return rewards;
        }
        set
        {
            rewards = value;
        }
    }
    public int[] RewardsQuantity
    {
        get
        {
            return rewardsQuantity;
        }
        set
        {
            rewardsQuantity = value;
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

    public int id;
    public string name;
    public string description;
    public float timeLimit;
    public int[] objective;
    public int[] objectiveQuantity;
    public int[] rewards;
    public int[] rewardsQuantity;
    public bool isMainQuest;

    public Quest(int id, string name, string description, float timeLimit, int[] objective, 
        int[] objectiveQuantity, int[] rewards, int[] rewardsQuantity, bool isMainQuest)
    {
        ID = id;
        Name = name;
        Description = description;
        TimeLimit = timeLimit;
        Objective = new int[objective.Length];
        for(int i = 0; i < objective.Length; i++)
        {
            Objective[i] = objective[i];
        }
        ObjectiveQuantity = new int[objectiveQuantity.Length];
        for (int i = 0; i < objectiveQuantity.Length; i++)
        {
            ObjectiveQuantity[i] = objectiveQuantity[i];
        }
        Rewards = new int[rewards.Length];
        for (int i = 0; i < rewards.Length; i++)
        {
            Rewards[i] = rewards[i];
        }
        RewardsQuantity = new int[rewardsQuantity.Length];
        for (int i = 0; i < rewardsQuantity.Length; i++)
        {
            RewardsQuantity[i] = rewardsQuantity[i];
        }
        IsMainQuest = isMainQuest;
    }
    public override bool Equals(object obj)
    {
        return (obj as Quest).ID == ID;
    }
    public override int GetHashCode()
    {
        return ID;
    }
}
