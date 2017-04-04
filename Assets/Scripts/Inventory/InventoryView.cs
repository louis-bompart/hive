using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryView : MonoBehaviour
{

    public GameObject inventoryPanel;
    public GameObject slotPanel;
    public GameObject inventorySlot;
    public GameObject inventoryItem;

    /// <summary>
    /// The slot amount.
    /// </summary>
    public int slotsAmount;
    /// <summary>
    /// please don't use me
    /// </summary>
    [System.Obsolete]
    private int freeSlot;

    public enum Inventory
    {
        Ship,
        Base
    }
    public Inventory inventory;
    //private string inventoryName;
    private InventoryModel inventoryModel;

    /// <summary>
    /// List of slots.
    /// </summary>
    public Slot[] slots;
    /// <summary>
    /// please don't use me
    /// </summary>
    [System.Obsolete]
    public int FreeSlot
    {
        get
        {
            return freeSlot;
        }

        set
        {
            freeSlot = value;
        }
    }

    /// <summary>
    /// which slots countains which item ? this allows the link between the models item and the view item.
    /// </summary>
    //public Dictionary<Item, int> itemsData = new Dictionary<Item, int>();

    /// <summary>
    /// instantiate item and slot list.
    /// </summary>
    void Awake()
    {
        InventoryModel.Inventory associatedModel = InventoryModel.Inventory.Ship;
        switch (inventory)
        {
            case Inventory.Ship:
                associatedModel = InventoryModel.Inventory.Ship;
                break;
            case Inventory.Base:
                associatedModel = InventoryModel.Inventory.Base;
                break;
            default:
                Debug.LogError("No inventory selected !", this);
                break;
        }
        Data data = FindObjectOfType<Data>();
        List<InventoryModel> models = new List<InventoryModel>(data.GetComponentsInChildren<InventoryModel>());
        //Sorry for the lambda
        inventoryModel = models.Find(x => x.inventoryType == associatedModel);
        // For now the nb of slots is hard-coded, most preferable option : Do some math to fix the size of each slot etc (not worth it 4 now)
        //slotAmount = InventoryModel.slotsAmount;
        freeSlot = slotsAmount;
        slots = slotPanel.GetComponentsInChildren<Slot>(true);
        //for (int i = 0; i < slotAmount; i++) {
        //	slots [i] = Instantiate (inventorySlot);
        //	slots [i].transform.SetParent (slotPanel.transform);
        //}
        slotsAmount = inventoryModel.slotCounts;
    }

    private void Start()
    {
        LoadInventory();
    }
    public void LoadInventory()
    {
        Dictionary<Item, int> inventoryDico = inventoryModel.inventory;
        foreach (Slot slot in slots)
        {
            slot.RemoveItem();
        }
        foreach (Item item in inventoryDico.Keys)
        {
            UpdateAddNewItemView(item, inventoryDico[item]);
        }
    }

    /// <summary>
    /// Check if a slot already got the item
    /// </summary>
    /// <param name="itemToCheck">The item searched</param>
    /// <returns>The slot contenaing the item, null if none had it</returns>
    private Slot getStackWithRoom(Item itemToCheck)
    {
        foreach (Slot slot in slots)
        {
            if (slot.hasItem(itemToCheck))
                if (slot.hasSomeRoom())
                    return slot;
        }
        return null;
    }
    /// <summary>
    /// Return the first empty slot available
    /// </summary>
    /// <returns>The slot found, or null if none has been found</returns>
    private Slot GetEmptySlot()
    {
        foreach (Slot slot in slots)
        {
            if (slot.isEmpty())
                return slot;
        }
        return null;
    }

    public bool hasFreeSlot()
    {
        return freeSlot > 0;
    }

    public void UpdateAddNewItemView(Item itemToAdd, int amount = 1)
    {
        if (amount > 0)
        {
            Slot slotToUse = null;
            bool isNewSlot = false;
            if (itemToAdd.StackSize > 0)
                slotToUse = getStackWithRoom(itemToAdd);
            else
            {
                slotToUse = GetEmptySlot();
                isNewSlot = true;
            }
            if (slotToUse == null && itemToAdd.StackSize > 0)
            {
                slotToUse = GetEmptySlot();
                isNewSlot = true;
            }
            if (slotToUse == null)
                Debug.LogError("No empty slot found in the view. That shouldn't happen.");
            else
            {
                //If the nb of item to add + the nb of item already in overflow the stack, then start a new stack with the overflow;
                int stackCurrentAmount = 0;
                int remainingAmount = 0;
                if (isNewSlot)
                {
                    inventoryModel.usedSlot++;
                    if (itemToAdd.StackSize > 0)
                        stackCurrentAmount = Math.Min(amount, itemToAdd.StackSize);
                    else
                        stackCurrentAmount = amount;
                }
                else
                {
                    stackCurrentAmount = Math.Min(slotToUse.Amount + amount, itemToAdd.StackSize);
                    //If the slot ain't empty, we erase the fancy picture for the new one. (No modification in the model :D)
                    slotToUse.RemoveItem();
                }
                if (itemToAdd.StackSize > 0)
                    remainingAmount = Math.Max(0, amount - stackCurrentAmount);
                //if (slotToUse.hasItem(itemToAdd))
                //    remainingAmount -= slotToUse.Amount;
                //if (remainingAmount > 0)
                //    amount = itemToAdd.stackSize;
                //if (slotToUse.hasItem(itemToAdd))
                //    amount -= slotToUse.Amount;
                GameObject itemObj = Instantiate(inventoryItem, slotToUse.GetComponent<RectTransform>()); // creates the itemView

                itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite; // sets the sprite
                itemObj.GetComponent<ItemData>().item = itemToAdd; // sets the item
                RectTransform position = itemObj.GetComponent<RectTransform>();
                position.offsetMin = new Vector2(1, 1);
                position.offsetMax = new Vector2(1, 1);
                position.localScale = new Vector3(1, 1, 1);
                //itemObj.transform.localPosition = Vector2.zero; // sets the position of the item according to the slot
                itemObj.name = itemToAdd.Title; // sets the name of the gameObject
                itemObj.transform.GetChild(0).GetComponent<Text>().text = stackCurrentAmount.ToString(); // sets the amount text
                itemObj.GetComponent<ItemData>().currentSlot = slotToUse;
                slotToUse.SetItem(itemObj.GetComponent<ItemData>());
                slotToUse.Amount = stackCurrentAmount;
                if (remainingAmount > 0)
                    UpdateAddNewItemView(itemToAdd, remainingAmount);
            }
        }

    }

    public void UpdateAmountView(Item itemToUpdate, int amount = 1)
    {

        LoadInventory();
        /*while (amount > 0)
        {
            Slot slot = findSlotWithItem(itemToUpdate);
            if (slot == null)
            {
                Debug.LogWarning("Not enough items in view");
            }
            else
            {
                if (amount <= slot.Amount)
                {
                    if (amount == slot.Amount)
                        slot.RemoveItem();
                    else
                        slot.Amount = slot.Amount - amount;
                    amount = 0;
                }
                else
                {
                    amount -= slot.Amount;
                    slot.RemoveItem();
                }
            }
        }
        */

        //int slot = itemsData[itemToUpdate]; // Gets the item slot position
        //slots[slot].transform.GetChild(0).GetChild(0).GetComponent<Text>().text = amount.ToString(); // updates the amount text
    }

    private Slot findSlotWithItem(Item itemToUpdate)
    {
        foreach (Slot slot in slots)
        {
            if (slot.hasItem(itemToUpdate))
                return slot;
        }
        return null;
    }

    public void ClearSlot(Slot slot)
    {
        slot.RemoveItem();
        inventoryModel.usedSlot--;
    }

    public void UpdateViewAfterRemoval(Item itemToRemove)
    {
        LoadInventory();
    }

    //public void updateMoveItemView(Item itemToMove, GameObject slotToFill)
    //{
    //    int slotToTakePos = itemsData[itemToMove]; // Gets the item slot position
    //    int slotToFillPos = -1;

    //    for (int i = 0; i < slotAmount; i++)
    //    { // Look for slotToFillPosition
    //        if (slots[i].GetInstanceID() == slotToFill.GetInstanceID())
    //        {
    //            slotToFillPos = i;
    //            break;
    //        }
    //    }

    //    if (slotToFill.transform.childCount == 0)
    //    { // Empty Slot
    //        slots[slotToTakePos].transform.GetChild(0).SetParent(slotToFill.transform); // Sets the parent of current itemToMove
    //        itemsData[itemToMove] = slotToFillPos; // Adds a new itemsData
    //    }
    //    else
    //    { // NotEmptySlot
    //        Item itemToReplace = null;
    //        foreach (Item key in itemsData.Keys)
    //        {
    //            if (itemsData[key] == slotToFillPos)
    //            {
    //                itemToReplace = key;
    //                break;
    //            }
    //        }

    //        slots[slotToTakePos].transform.GetChild(0).SetParent(slotToFill.transform); // Sets the parent of current itemToMove
    //        slotToFill.transform.GetChild(0).position = slots[slotToTakePos].transform.position; // Sets the position of current itemToReplace
    //        slotToFill.transform.GetChild(0).SetParent(slots[slotToTakePos].transform); // Sets the parent of current itemToReplace

    //        itemsData[itemToMove] = slotToFillPos; // Updates informations about itemtomove slot
    //        itemsData[itemToReplace] = slotToTakePos; // Updates informations about itemtoreplace slot
    //    }

    //}

}


