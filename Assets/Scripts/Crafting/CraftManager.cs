using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Inventory;
using ItemNS;

public class CraftManager : MonoBehaviour
{


    //public InventoryModel inventoryModel;
    private static InventoryController inventoryController;

    public GameObject craftPanel;
    public GameObject[] recipePanel;

    public GameObject recipeSlot;

    public GameObject craftSlot;
    public GameObject craftItem;


    /// <summary>
    /// The category amount.
    /// </summary>
    public int categoryAmount = 4;

    public TextAsset craftJSON;

    /// <summary>
    /// The databases.
    /// </summary>
    private CraftDatabase database;
    private ItemDatabase idatabase;

    private void Awake()
    {
        inventoryController = new List<InventoryController>(GameObject.FindObjectsOfType<InventoryController>()).Find(x => x.inventoryType == InventoryController.Inventory.Ship);
    }

    /// <summary>
    /// instantiate item and slot list.
    /// </summary>
    void Start()
    {
        database = CraftDatabase.Instance(craftJSON);
        ItemDatabase.GetInstance(out idatabase);

        for (int i = 0; i < database.database.Count; i++)
        {
            AddCraft(database.database[i].id);
        }

        int impS = Data.instance.GetComponentInChildren<BaseStats>().printerStat;
        for (int t = 0; t < recipePanel.Length; t++)
        {
            recipePanel[t].SetActive(false);
        }
        for (int i = 0; i < impS && i < recipePanel.Length; i++)
        {
            recipePanel[i].SetActive(true);
        }

    }

    public void AddCraft(int id)
    {
        Craft craftToAdd = database.FetchCraftByID(id);

        if (craftToAdd == null) // if the id does not exist.
        {
            Debug.Log("craftIdNotFound");
            return;
        }


        // Instantiate the recipeItem 

        int category = craftToAdd.category;
        GameObject recipeslt = Instantiate(recipeSlot);
        recipeslt.transform.SetParent(recipePanel[category].transform.Find("Panel"), false);// Add a recipeSlot in the approppriate Panel
        //recipeslt.transform.GetChild(3).gameObject.SetActive(true); // Lock the receipt
        Transform product = recipeslt.transform.Find("Slot").Find("Product Panel");
        Transform component = recipeslt.transform.Find("Slot").Find("Component Panel");

        // Instantiate the productItem 

        int productID = craftToAdd.itemsID[0];
        int productAmount = craftToAdd.itemsAmount[0];

        Item productItem = idatabase.FetchItemByID(productID);
        ItemView productObj = ItemView.CreateStandalone(productItem, productAmount);
        productObj.transform.SetParent(product, false);
        productObj.transform.localPosition = Vector2.zero; // sets the position of the item according to the slot
        //productObj.transform.localPosition = Vector2.zero; // sets the position of the item according to the slot
        productObj.transform.localScale = Vector3.one;
        // Instantiate the componentItems 

        int numberOfComp = craftToAdd.itemsID.Length - 1;
        int[] componentID = new int[numberOfComp];
        int[] componentAmount = new int[numberOfComp];

        Item[] componentItem = new Item[numberOfComp];

        for (int i = 0; i < numberOfComp; i++)
        {
            componentID[i] = craftToAdd.itemsID[i + 1];
            componentAmount[i] = craftToAdd.itemsAmount[i + 1];
            componentItem[i] = idatabase.FetchItemByID(componentID[i]);
        }

        for (int i = 0; i < numberOfComp; i++)
        {
            //recipeslt.transform.GetChild(1);
            ItemView compObj = ItemView.CreateStandalone(componentItem[i], productAmount);
            compObj.transform.SetParent(component, false);
            compObj.transform.localPosition = Vector2.zero; // sets the position of the item according to the slot
            compObj.transform.localScale = Vector3.one;

        }

        // Instantiate the create Button Function 

        Button button = recipeslt.GetComponentInChildren<Button>();
        button.onClick.AddListener(() =>
        {
            createObject(productID, productAmount, componentID, componentAmount);
        });
        product.GetComponent<HorizontalFitter>().Refit();
        //component.GetComponent<HorizontalFitter>().Refit();
        LayoutRebuilder.ForceRebuildLayoutImmediate(component.GetComponent<RectTransform>());
        float width = component.GetComponent<RectTransform>().rect.width;
        float height = component.GetComponent<RectTransform>().rect.height - component.GetComponent<GridLayoutGroup>().padding.vertical;
        float size = Mathf.Min(width, height) / Mathf.Sqrt(component.transform.childCount);
        component.GetComponent<GridLayoutGroup>().cellSize = new Vector2(size - component.GetComponent<GridLayoutGroup>().spacing.x, size - component.GetComponent<GridLayoutGroup>().spacing.y);
        LayoutRebuilder.MarkLayoutForRebuild(product.GetComponent<RectTransform>());
        LayoutRebuilder.MarkLayoutForRebuild(recipeslt.GetComponent<RectTransform>());
        LayoutRebuilder.MarkLayoutForRebuild(GetComponent<RectTransform>());
    }

    public void createObject(int productID, int productAmount, int[] componentID, int[] componentAmount)
    {

        //Dictionary<Item, int> inventory = inventoryModel.inventory;

        // Does the inventory contains the components ? 

        bool isCreatable = true;

        for (int k = 0; k < componentID.Length && isCreatable; k++)
        { // looping on the 
          //ToDo use the controller with GetQuantity()
            if (countItemId(componentID[k]) < componentAmount[k])
            {
                isCreatable = false;
            }
        }

        if (isCreatable && inventoryController.CanItFit(productID, productAmount))
        { // Enough of every components
          // Adds the product a productAmount of times 
            inventoryController.AddItem(productID, productAmount);
            GameObject.Find("Data").GetComponentInChildren<OtherStats>().CraftedItems++;
            // Remove the components 

            for (int k = 0; k < componentID.Length; k++)
            {// looping on the components
                inventoryController.RemoveItem(componentID[k], componentAmount[k]);
            }


        }
        else
        {
            Debug.Log("Component not creatable");
        }
    }

    private int countItemId(int id)
    {
        return inventoryController.GetQuantity(id);
    }
}