using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestProgress : MonoBehaviour {

    public int questProgress;
    public List<int> CompletedQuests;

    private void Awake()
    {
        if (CompletedQuests == null)
        {
            CompletedQuests = new List<int>();
        }
    }
}
