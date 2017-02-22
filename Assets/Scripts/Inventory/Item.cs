using UnityEngine;

[System.Serializable]
public class Item
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
    public bool Stackable
    {
        get
        {
            return stackable;
        }
        set
        {
            stackable = value;
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
    public string title;
    public int price;
    public string description;
    public bool stackable;
    public string slug;
    public void SetSprite()
    {
        this.Sprite = Resources.Load<Sprite>("UIImage/" + slug);
    }

    public Item(int id, string title, int value, string description, bool stackable, string slug)
    {
        this.ID = id;
        this.Title = title;
        this.Price = value;
        this.Description = description;
        this.Stackable = stackable;
        this.Slug = slug;
        SetSprite();
    }

    public override bool Equals(object obj)
    {
        return (obj as Item).ID == this.ID;
    }
    public override int GetHashCode()
    {
        return ID;
    }
}