using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject slotPanel;
    public GameObject inventorySlot;
    public GameObject inventoryItem;

    public int slotAmount = 12;

    public List<Item> items = new List<Item>(20);
    public List<GameObject> slots = new List<GameObject>();
    public TextAsset itemJSON;

    private ItemDatabase database;

    void Start()
    {
        database = ItemDatabase.Instance(itemJSON);

        for (int i = 0; i < slotAmount; i++)
        {
            //items.Add(new Item());
            slots.Add(Instantiate(inventorySlot));
            slots[i].GetComponent<Slot>().id = i;
            slots[i].transform.SetParent(slotPanel.transform);
        }

        AddItem(0);
        AddItem(0);
        AddItem(1);
        AddItem(1);
        AddItem(1);
    }

    public void AddItem(int id)
    {
        Item itemToAdd = database.FetchItemByID(id);
        if (itemToAdd == null)
        {
            Debug.Log("itemIdNotFound id : " + id);
            return;
        }
        if (itemToAdd.Stackable && items.Contains(itemToAdd))
        {
            for (int i = 0; i < items.Count; i++)
            {
                //if (items[i].ID == id)
                if (items[i].Equals(itemToAdd))
                {
                    ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount++;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                }

            }
        }
        else
        {
            //Proposition 1: items.Capacity
            for (int i = items.Count; i < slots.Count; i++)
            {
                items.Add(itemToAdd);
                GameObject itemObj = Instantiate(inventoryItem);

                itemObj.GetComponent<ItemData>().item = itemToAdd;
                itemObj.GetComponent<ItemData>().slot = i;
                itemObj.GetComponent<ItemData>().amount = 1;

                itemObj.transform.SetParent(slots[i].transform);
                itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                itemObj.transform.position = Vector2.zero;
                itemObj.name = itemToAdd.Title;
                break;
            }
        }
    }

    //bool isItemInInventory(Item item)
    //{
    //    for (int i = 0; i < items.Count; i++)
    //    {
    //        if (items[i].ID == item.ID)
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}
}
