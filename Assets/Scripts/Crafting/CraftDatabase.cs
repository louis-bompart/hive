using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class CraftDatabase
{
	public List<Craft> database = new List<Craft>();
	private static CraftDatabase instance;

	private CraftDatabase(TextAsset craftDataBaseJson)
	{
		instance = JsonUtility.FromJson<CraftDatabase>(craftDataBaseJson.text);
		foreach (Craft craft in instance.database)
		{
			craft.SetSprite();
		}
	}

	public Craft FetchCraftByID(int id)
	{
		for (int i = 0; i < instance.database.Count; i++)
		{
			if (database[i].ID == id)
				return database[i];
		}
		return null;
	}

	public static CraftDatabase Instance(TextAsset json)
	{
		if (instance == null)
		{
			new CraftDatabase(json);
		}
		return instance;
	}

}