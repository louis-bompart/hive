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
    public enum Inventory
    {
        Ship,
        Base,
        Both
    }
    public Inventory inventory;
    private string inventoryName;
    private InventoryModel inventoryModel;
    private int freeSlot;
    private InventoryView inventoryView;
    private Dictionary<Inventory, InventoryController> childrenControllers;
    InventoryModel.Inventory associatedModel;
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
    private InventoryController GetNewInvController(Inventory kind)
    {
        Inventory tmp = inventory;
        inventory = kind;
        InventoryController toReturn = Instantiate<InventoryController>(this);
        inventory = tmp;
        return toReturn;
    }

    void Awake()
    {
        childrenControllers = new Dictionary<Inventory, InventoryController>();
        database = ItemDatabase.Instance(itemJSON);
        associatedModel = InventoryModel.Inventory.Ship;
        switch (inventory)
        {
            case Inventory.Ship:
                associatedModel = InventoryModel.Inventory.Ship;
                break;
            case Inventory.Base:
                associatedModel = InventoryModel.Inventory.Base;
                break;
            case Inventory.Both:
                Debug.Log("Super inventory mode enable, woh woh woh (yeah this controller act now on all inventories, beware)", this);
                childrenControllers.Add(Inventory.Base, GetNewInvController(Inventory.Base));
                childrenControllers.Add(Inventory.Ship, GetNewInvController(Inventory.Ship));
                break;
            default:
                Debug.LogError("No inventory selected !", this);
                break;
        }
        Data data = FindObjectOfType<Data>();
        List<InventoryModel> models = new List<InventoryModel>(data.GetComponentsInChildren<InventoryModel>());
        //Sorry for the lambda
        inventoryModel = models.Find(x => x.inventoryType == associatedModel);
        //inventoryModel = GameObject.Find(inventoryName).GetComponent<InventoryModel>();
        inventoryView = this.gameObject.GetComponent<InventoryView>();
        //FreeSlot = inventoryView.slotsAmount;
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (inventoryModel == null && inventory != Inventory.Both)
        {
            Debug.LogWarning("Oups, inventory lost. Trying to recover...");
            Data data = FindObjectOfType<Data>();
            List<InventoryModel> models = new List<InventoryModel>(data.GetComponentsInChildren<InventoryModel>());
            inventoryModel = models.Find(x => x.inventoryType == associatedModel);
            //inventoryModel = GameObject.Find(inventoryName).GetComponent<InventoryModel>();
            if (inventoryModel == null)
                Debug.LogError("Snap, inventory recovery failed, we're in trouble !");
            else
                Debug.Log("Inventory Recovered, all good !");
        }
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

    public int FittableAmount(int itemID)
    {
        return FittableAmount(database.FetchItemByID(itemID));
    }

    private int FittableAmount(Item item)
    {
        if (childrenControllers.Count > 0)
        {
            int toReturn = 0;
            inventoryModel.inventory.TryGetValue(item, out toReturn);
            toReturn %= item.StackSize;
            toReturn += inventoryModel.GetNbFreeSlot() * item.StackSize;
            return toReturn;
        }
        else
        {
            int toReturn = 0;
            foreach (InventoryController controller in childrenControllers.Values)
            {
                toReturn += controller.FittableAmount(item);
            }
            return toReturn;
        }
    }

    private void UpdateAllViewsOnScene()
    {
        foreach (InventoryView view in FindObjectsOfType<InventoryView>())
        {
            view.LoadInventory();
        }
    }

    /// <summary>
    /// Adds the item and its amount to the dictionnary.
    /// </summary>
    /// <param name="itemToAdd">Item to add.</param>
    /// <param name="amount">Amount.</param>
    public bool AddItem(int itemID, int amount = 1)
    {
        if (childrenControllers.Count > 0)
        {
            int baseAmount = childrenControllers[Inventory.Base].FittableAmount(itemID);
            int shipAmount = childrenControllers[Inventory.Ship].FittableAmount(itemID);
            if (amount < baseAmount + shipAmount)
            {
                childrenControllers[Inventory.Base].AddItem(itemID, Mathf.Min(baseAmount, amount));
                amount -= baseAmount;
                if (amount > 0)
                {
                    childrenControllers[Inventory.Ship].AddItem(itemID, Mathf.Min(shipAmount, amount));
                }
                UpdateAllViewsOnScene();
                return true;
            }
            else
                return false;
        }
        Item itemToAdd = database.FetchItemByID(itemID);

        //// if the item is already in the list and is stackable
        //if (itemToAdd.StackSize > 0 && inventory.ContainsKey(itemToAdd))
        //{
        if (CanItFit(itemToAdd, amount))
        {
            // updates the amount of the model
            Dictionary<Item, int> model = inventoryModel.inventory;
            int currentAmount = 0;
            if (model.TryGetValue(itemToAdd, out currentAmount))
                model.Remove(itemToAdd);
            model.Add(itemToAdd, currentAmount + amount);
            // updates the view
            if (inventoryView != null)
                inventoryView.UpdateAddNewItemView(itemToAdd, amount);
            return true;
        }
        return false;
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
        return CanItFit(database.FetchItemByID(itemID), amount);
    }

    private bool CanItFit(Item itemToAdd, int amount)
    {
        if (childrenControllers.Count > 0)
        {
            bool toReturn = true;
            toReturn = toReturn && childrenControllers[Inventory.Ship].canItFit(itemToAdd.ID, amount);
            toReturn = toReturn && childrenControllers[Inventory.Base].canItFit(itemToAdd.ID, amount);
            return toReturn;
        }
        else
        {
            //If the item cannot be stacked
            if (itemToAdd.stackSize < 1)
                return inventoryModel.HasFreeSlot();
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
            return inventoryModel.GetNbFreeSlot() >= slotRequired;
        }
    }

    public void RemoveItem(ItemData item)
    {
        //ToDo Need to rework dat part
        if (inventory != Inventory.Both)
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
            if (inventoryView != null)
                inventoryView.ClearSlot(item.currentSlot);
        }
    }

    /// <summary>
    /// Removes the item (or at least reduce its amount).
    /// </summary>
    /// <param name="itemToRemove">Item to remove.</param>
    /// <param name="amount">Amount.</param>
    public void RemoveItem(int itemID, int amount = 1)
    {
        Item itemToRemove = database.FetchItemByID(itemID);
        if (childrenControllers.Count > 0)
        {
            int baseAmount = childrenControllers[Inventory.Base].GetQuantity(itemToRemove);
            int shipAmount = childrenControllers[Inventory.Ship].GetQuantity(itemToRemove);
            if (amount < baseAmount + shipAmount)
            {
                childrenControllers[Inventory.Base].RemoveItem(itemID, Mathf.Min(amount, baseAmount));
                amount -= baseAmount;
                if (amount > 0)
                {
                    childrenControllers[Inventory.Ship].RemoveItem(itemID, Mathf.Min(amount, shipAmount));
                    amount -= shipAmount;
                }
            }
            UpdateAllViewsOnScene();
        }
        else
        {
            //Dictionary<Item, int> inventory = inventoryModel.inventory;

            if (inventoryModel.inventory.ContainsKey(itemToRemove))
            { // if the item is in the list
                if (amount <= inventoryModel.inventory[itemToRemove])
                { // if the amount to remove or equal is lower than the amount in the inventory
                    inventoryModel.inventory[itemToRemove] -= amount; // updates the amount of the model
                    if (inventoryView != null)
                        inventoryView.UpdateAmountView(itemToRemove, inventoryModel.inventory[itemToRemove]); // updates the view
                    inventoryView.LoadInventory();
                }
                else
                    Debug.LogWarning("Try to remove more item than available in the model, ain't right");
            }
        }
    }

}
