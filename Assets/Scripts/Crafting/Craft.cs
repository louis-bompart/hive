using UnityEngine;

[System.Serializable]
public class Craft
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
	public int Category
	{
		get
		{
			return category;
		}
		set
		{
			category = value;
		}
	}
	public string Title
	{
		get
		{
			return title;
		}
		set
		{
			title = value;
		}
	}
	public int Price
	{
		get
		{
			return price;
		}
		set
		{
			price = value;
		}
	}
	public int NbItems
	{
		get
		{
			return nbItems;
		}
		set
		{
			nbItems = value;
		}
	}
	public int[] ItemsID
	{
		get
		{
			return itemsID;
		}
		set
		{
			itemsID = value;
		}
	}
	public int[] ItemsAmount
	{
		get
		{
			return itemsAmount;
		}
		set
		{
			itemsAmount = value;
		}
	}


	public string Slug
	{
		get
		{
			return slug;
		}
		set
		{
			slug = value;
		}
	}

	public Sprite Sprite { get; set; }

	public int id;
	public int category;
	public string title;
	public int price;
	public int nbItems;
	public int[] itemsID;
	public int[] itemsAmount;
	public string slug;

	public void SetSprite()
	{
		this.Sprite = Resources.Load<Sprite>("UIImage/" + slug);
	}

	public Craft(int id, int category, string title, int value, int nbItems, int[] itemsID, int[] itemsAmount, string slug)
	{
		this.ID = id;
		this.Category = category;
		this.Title = title;
		this.Price = value;
		this.nbItems = nbItems;
		this.itemsID = new int[nbItems];
		for (int i = 0; i < nbItems; i++) {
			this.itemsID [i] = itemsID [i];
		}
		for (int i = 0; i < nbItems; i++) {
			this.itemsAmount [i] = itemsAmount [i];
		}

		this.Slug = slug;
		SetSprite();
	}

	public Craft(){
		this.ID = -1;
	}

	public override bool Equals(object obj)
	{
		return (obj as Craft).ID == this.ID;
	}
	public override int GetHashCode()
	{
		return ID;
	}
		
}