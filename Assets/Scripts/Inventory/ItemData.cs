using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Handle all the UX-thingies for the item
/// </summary>
public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{

    /// <summary>
    /// The item
    /// </summary>
    public Item item;
    public Slot currentSlot;

    private InventoryView inventoryView;
    private Vector2 offset;

    /// <summary>
    /// The tooltip.
    /// </summary>
    private Tooltip tooltip;


    void Start()
    {
        inventoryView = GetComponentInParent<InventoryView>();
        if (inventoryView == null)
            inventoryView = GameObject.Find("Inventory").GetComponent<InventoryView>();
        tooltip = inventoryView.GetComponent<Tooltip>();
    }

    /// <summary>
    /// eventCalled when an itemData begins to be dragged
    /// </summary>
    /// <param name="eventData">Event data.</param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item != null)
        { // there is an item 
            offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
            //	this.transform.SetParent (this.transform.parent.parent);
            this.transform.position = eventData.position - offset;
            this.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    /// <summary>
    /// eventCalled when an itemData is being be dragged
    /// </summary>
    /// <param name="eventData">Event data.</param>
    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        { // there is an item 
            this.transform.position = eventData.position - offset;
        }
    }

    /// <summary>
    /// eventCalled when an itemData finishes to be dragged
    /// </summary>
    /// <param name="eventData">Event data.</param>
    public void OnEndDrag(PointerEventData eventData)
    {
        if (item != null)
        { // there is an item 
            RectTransform position = GetComponent<RectTransform>();
            position.offsetMin = new Vector2(1, 1);
            position.offsetMax = new Vector2(1, 1);
            position.localScale = new Vector3(1, 1, 1);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }

    }

    /// <summary>
    /// activates the tooltip when the mouse enters the itemData
    /// </summary>
    /// <param name="eventData">Event data.</param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.Activate(item);
    }

    /// <summary>
    ///  activates the tooltip when the mouse exits the itemData
    /// </summary>
    /// <param name="eventData">Event data.</param>
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        tooltip.Deactivate();
    }
}
