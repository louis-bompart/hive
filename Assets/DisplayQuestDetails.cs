using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayQuestDetails : MonoBehaviour {


    private Quest quest;
    public GameObject namePanel;
    public GameObject clientPanel;
    public GameObject descriptionPanel;
    public GameObject objectivePanel;
    public GameObject rewardPanel;
    public TextAsset itemJSON;
    private ItemDatabase itemDataBase;
    
    

	// Use this for initialization
	void Start () {
        quest = GetComponent<QuestSlot>().quest;
        itemDataBase = ItemDatabase.Instance(itemJSON);
        if (quest.IsMainQuest) { Display();}
    }

    // Update is called once per frame
    void Update () {

    }

    public void Display() {
        quest = GetComponent<QuestSlot>().quest;
        namePanel.GetComponentInChildren<Text>().text = quest.QuestName;
        clientPanel.GetComponentInChildren<Text>().text = "Client : " + quest.Client;
        descriptionPanel.GetComponentInChildren<Text>().text = quest.Description;
        string objective = "";
        var objectiveQuantities = quest.ObjectiveQuantityList;
        var objectiveItems = quest.ObjectiveList;
        int i = 0;
        while(i < objectiveQuantities.Count) {
            int quantity = objectiveQuantities[i];
            objective += quantity.ToString() + " ";
            Item item = itemDataBase.FetchItemByID(objectiveItems[i]);
            objective += item.Title;
            if (i < objectiveQuantities.Count - 1) {
                objective += "\n";
            }
            i++;
        }
        objectivePanel.GetComponentInChildren<Text>().text = objective;
        string reward = "";
        var rewardQuantities = quest.RewardQuantityList;
        var rewardItems = quest.RewardList;
        int j = 0;
        while (j < rewardQuantities.Count) {
            int rewardQuantity = rewardQuantities[j];
            reward += rewardQuantity.ToString() + " ";
            Item rewardItem = itemDataBase.FetchItemByID(rewardItems[j]);
            reward += rewardItem.Title;
            if (j < rewardQuantities.Count - 1) {
                reward += "\n";
            }
            j++;
        }
        rewardPanel.GetComponentInChildren<Text>().text = reward;

    }
}
