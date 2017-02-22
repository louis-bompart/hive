using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class ItemDatabase
{
    public List<Item> database = new List<Item>();
    private static ItemDatabase instance;

    private ItemDatabase(TextAsset itemDataBaseJson)
    {
        instance = JsonUtility.FromJson<ItemDatabase>(itemDataBaseJson.text);
        foreach (Item item in instance.database)
        {
            item.SetSprite();
        }
    }

    public Item FetchItemByID(int id)
    {
        for (int i = 0; i < instance.database.Count; i++)
        {
            if (database[i].ID == id)
                return database[i];
        }
        return null;
    }

    public static ItemDatabase Instance(TextAsset json)
    {
        if (instance == null)
        {
            new ItemDatabase(json);
        }
        return instance;
    }
}