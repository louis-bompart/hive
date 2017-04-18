using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inventory
{
    public class ItemView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
    {
        internal static GameObject prefab;
        internal int amount;
        public Text amountView;
        internal SlotView currentSlot;
        bool isStandalone;

        internal static ItemView Create(SlotView slot)
        {
            ItemView toReturn = Instantiate(prefab).GetComponent<ItemView>();
            toReturn.currentSlot = slot;
            toReturn.isStandalone = false;
            toReturn.amount = Slot.GetSlotFromId(slot.slotID).amount;
            toReturn.amountView.text = toReturn.amount.ToString();
            toReturn.GetComponent<Image>().sprite = Slot.GetSlotFromId(slot.slotID).item.Sprite;
            return toReturn;
        }

        public static ItemView CreateStandalone(ItemNS.Item item, int amount)
        {
            ItemView toReturn = Instantiate(prefab).GetComponent<ItemView>();
            toReturn.isStandalone = true;
            toReturn.GetComponent<Image>().sprite = item.Sprite;
            toReturn.amount = amount;
            toReturn.amountView.text = toReturn.amount.ToString();
            return toReturn;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (isStandalone)
                return;
            transform.SetParent(currentSlot.transform.root, true);
            this.transform.position = eventData.position;
            this.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (isStandalone)
                return;
            this.transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (isStandalone)
                return;
            transform.SetParent(currentSlot.transform, true);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            GetComponent<RectTransform>().localPosition = Vector3.zero;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (isStandalone)
                return;
            Tooltip.instance.Activate(Slot.GetSlotFromId(currentSlot.slotID).item);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (isStandalone)
                return;
            Tooltip.instance.Desactivate();
        }
    }
}