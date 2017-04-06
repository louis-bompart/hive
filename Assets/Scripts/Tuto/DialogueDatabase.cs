using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class DialogueDatabase
{
    public List<DialogueDataItem> database = new List<DialogueDataItem>();
    private static DialogueDatabase instance;

    private DialogueDatabase(TextAsset dialogueDatabase)
    {
        instance = JsonUtility.FromJson<DialogueDatabase>(dialogueDatabase.text);
        
    }

    static public void initDatabase(TextAsset data)
    {
        new DialogueDatabase(data);
    }

    public DialogueDataItem getDialogue(string id)
    {
        for (int i = 0; i < instance.database.Count; i++)
        {
            if (database[i].ID == id)
                return database[i];
        }
        return new DialogueDataItem("null","Dialogue missing from Database ID : " + id,0);
    }

    public static DialogueDatabase Instance()
    {
        if (instance == null)
        {
            Debug.Log("No instance of DialogueDatabese");
        }
        return instance;
    }
}
