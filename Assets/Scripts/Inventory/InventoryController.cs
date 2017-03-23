using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{

    public TextAsset itemJSON;

    /// <summary>
    /// The database.
    /// </summary>
    private ItemDatabase database;

    private InventoryModel inventoryModel;
    private int freeSlot;
    private InventoryView inventoryView;
    //public int FreeSlot
    //{
    //    get
    //    {
    //        return freeSlot;
    //    }

    //    set
    //    {
    //        freeSlot = value;
    //    }
    //}

    void Start()
    {
        database = ItemDatabase.Instance(itemJSON);
        inventoryModel = this.gameObject.GetComponent<InventoryModel>();
        inventoryView = this.gameObject.GetComponent<InventoryView>();
        //FreeSlot = inventoryView.slotsAmount;
    }

    public int GetQuantity(Item item)
    {
        int output = 0;
        inventoryModel.inventory.TryGetValue(item, out output);
        return output;
    }

    public int GetQuantity(int itemID)
    {
        return GetQuantity(database.FetchItemByID(itemID));
    }
    /// <summary>
    /// Adds the item and its amount to the dictionnary.
    /// </summary>
    /// <param name="itemToAdd">Item to add.</param>
    /// <param name="amount">Amount.</param>
    public void AddItem(int itemID, int amount = 1)
    {
        Item itemToAdd = database.FetchItemByID(itemID);

        //// if the item is already in the list and is stackable
        //if (itemToAdd.StackSize > 0 && inventory.ContainsKey(itemToAdd))
        //{
        if (canItFit(itemToAdd, amount))
        {
            // updates the amount of the model
            Dictionary<Item, int> model = inventoryModel.inventory;
            int currentAmount = 0;
            if (model.TryGetValue(itemToAdd, out currentAmount))
                model.Remove(itemToAdd);
            model.Add(itemToAdd, currentAmount + amount);
            // updates the view
            inventoryView.updateAddNewItemView(itemToAdd, amount);
        }
        //    ////If one slot still have some room for the amount to add
        //    //if (inventory[itemToAdd] + amount % itemToAdd.StackSize > 0)
        //    //{

        //    //}
        //    //else if (inventoryView.hasFreeSlot())
        //    //{
        //    //    inventory[itemToAdd] += amount;
        //    //    // updates the view
        //    //    inventoryView.updateAmountItemView(itemToAdd, inventory[itemToAdd]);
        //    //}

        //}
        //// if the item is not in the list
        //else
        //{
        //    // if there is enough room.
        //    if (canItFit(itemToAdd, amount))
        //    {
        //        // updates the view
        //        // adds the item and its amount of the model
        //        inventory.Add(itemToAdd, amount);
        //        inventoryView.updateAddNewItemView(itemToAdd, amount);
        //    }
        //}
    }

    public bool canItFit(int itemID, int amount)
    {
        return canItFit(database.FetchItemByID(itemID), amount);
    }

    private bool canItFit(Item itemToAdd, int amount)
    {
        //If the item cannot be stacked
        if (itemToAdd.stackSize < 1)
            return inventoryView.hasFreeSlot();
        int quantityYet = 0;
        inventoryModel.inventory.TryGetValue(itemToAdd, out quantityYet);
        //First we check if we can just fill some slots
        if (quantityYet % itemToAdd.stackSize + amount >= amount)
            return true;
        amount -= quantityYet;
        //Then if not good yet, we check how many slots we need to stock it all.
        int slotRequired = amount / itemToAdd.stackSize;
        if (amount % itemToAdd.stackSize > 0)
            slotRequired++;
        return inventoryView.FreeSlot >= slotRequired;

    }

    public void RemoveItem(ItemData item)
    {
        Item itemToRemove = item.item;
        Dictionary<Item, int> inventory = inventoryModel.inventory;

        if (inventory.ContainsKey(itemToRemove))
        { // if the item is in the list
            if (item.currentSlot.Amount < inventory[itemToRemove])
            { // if the amount to remove is lower than the amount in the inventory
                inventory[itemToRemove] -= item.currentSlot.Amount; // updates the amount of the model
            }
            else
            { // remove the item completely
                if (item.currentSlot.Amount > inventory[itemToRemove])
                    Debug.Log("Possible bug, on a essayer d'enlever des items en rab");
                inventory.Remove(itemToRemove); // remove the item
            }
        }
        inventoryView.ClearSlot(item.currentSlot);
    }

    /// <summary>
    /// Removes the item (or at least reduce its amount).
    /// </summary>
    /// <param name="itemToRemove">Item to remove.</param>
    /// <param name="amount">Amount.</param>
    public void RemoveItem(int itemID, int amount = 1)
    {
        Item itemToRemove = database.FetchItemByID(itemID);

        Dictionary<Item, int> inventory = inventoryModel.inventory;

        if (inventory.ContainsKey(itemToRemove))
        { // if the item is in the list
            if (amount < inventory[itemToRemove])
            { // if the amount to remove is lower than the amount in the inventory
                inventory[itemToRemove] -= amount; // updates the amount of the model
                inventoryView.updateAmountItemView(itemToRemove, inventory[itemToRemove]); // updates the view
            }
            else
            { // remove the item completely
                if (amount > inventory[itemToRemove])
                    Debug.LogWarning("Try to remove more item than available in the model, ain't right");
                inventory.Remove(itemToRemove); // remove the item
                inventoryView.updateRemoveItemView(itemToRemove); // updates the view
            }
        }
    }

}
