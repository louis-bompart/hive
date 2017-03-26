using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{

    private InventoryView inventoryView;
    private ItemData item;
    private int amount;

    public int Amount
    {
        get
        {
            return amount;
        }

        set
        {
            amount = value;
        }
    }

    void Start()
    {
        inventoryView = GameObject.Find("Inventory").GetComponent<InventoryView>();
        item = null;
        Amount = -1;
    }

    public bool hasItem(Item item)
    {
        if (this.item == null)
            return false;
        return this.item.item.Equals(item);
    }

    public bool hasSomeRoom()
    {
        return Amount < item.item.stackSize;
    }

    public bool isEmpty()
    {
        return item == null;
    }

    /// <summary>
    /// Set the item of the slot -no update on model, beware-
    /// </summary>
    /// <param name="item">the item to put in</param>
    public void SetItem(ItemData item)
    {
        this.item = item;
    }
    /// <summary>
    /// Remove the item of the slot -no update on model, beware-
    /// </summary>
    public void RemoveItem()
    {
        Destroy(item.gameObject);
        SetItem(null);
    }

    /// <summary>
    /// Event called when an element is dropped in a slot.
    /// </summary>
    /// <param name="eventData">Mouse Pointer eventData</param>
    public void OnDrop(PointerEventData eventData)
    {
        ItemData dragged = eventData.pointerDrag.GetComponent<ItemData>();
        if (dragged != null)
        {
            //inventoryView.updateMoveItemView(dragged.item, this.gameObject);
            item = dragged;
            dragged.currentSlot.item = null;
            dragged.currentSlot = this;
            dragged.transform.SetParent(this.transform);
            RectTransform position = dragged.GetComponent<RectTransform>();
            position.offsetMin = new Vector2(1, 1);
            position.offsetMax = new Vector2(1, 1);
            position.localScale = new Vector3(1, 1, 1);
        }
    }




}
