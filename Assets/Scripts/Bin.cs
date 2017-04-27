using System;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Inventory
{
    internal class Bin : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            ItemView dragged = eventData.pointerDrag.GetComponent<ItemView>();
            SlotView other = dragged.currentSlot;
            Slot sl = Slot.GetSlotFromId(other.slotID);
            InventoryController.getInventoryType(InventoryController.Inventory.Both).RemoveItem(sl.item.id,sl.amount);
            sl.ClearSlot();
        }
    }
}