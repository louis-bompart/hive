using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryModel : MonoBehaviour
{
    public enum Inventory
    {
        Ship,
        Base
    }
    public Inventory inventoryType;
    public Dictionary<Item, int> inventory = new Dictionary<Item, int>();
    //public List<KeyValuePair<Item, int>> slots = new List<KeyValuePair<Item, int>>();
    public int slotCounts;
    public int usedSlot;
    public void Awake()
    {
        switch (inventoryType)
        {
            case Inventory.Ship:
                slotCounts = 20;
                break;
            case Inventory.Base:
                slotCounts = 48;
                break;
            default:
                break;
        }
    }

    public int GetNbFreeSlot()
    {
        return slotCounts - usedSlot;
    }

    public bool HasFreeSlot()
    {
        return GetNbFreeSlot() > 0;
    }
}
