using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftManager : MonoBehaviour
{

    
    public InventoryModel inventoryModel;
    public InventoryController inventoryController;

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
    public TextAsset itemJSON;

    /// <summary>
    /// The databases.
    /// </summary>
    private CraftDatabase database;
    private ItemDatabase idatabase;

    /// <summary>
    /// instantiate item and slot list.
    /// </summary>
    void Start()
    {
        database = CraftDatabase.Instance(craftJSON);
        idatabase = ItemDatabase.Instance(itemJSON);




        for(int i = 0; i<database.database.Count;i++)
        {
            AddCraft(database.database[i].id);
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
        GameObject recipeslt = Instantiate(recipeSlot, recipePanel[category].transform.Find("Panel")); // Add a recipeSlot in the approppriate Panel
        //recipeslt.transform.GetChild(3).gameObject.SetActive(true); // Lock the receipt

        // Instantiate the productItem 

        int productID = craftToAdd.itemsID[0];
        int productAmount = craftToAdd.itemsAmount[0];

        Item productItem = idatabase.FetchItemByID(productID);

        GameObject productObj = Instantiate(craftItem, recipeslt.transform.GetChild(0).GetChild(0)); // creates the productItem gameObject in the productSlot of the product panel of the recipeSlot

        productObj.GetComponent<Image>().sprite = productItem.Sprite; // sets the sprite
        productObj.GetComponent<ItemData>().item = productItem; // sets the item

        productObj.transform.localPosition = Vector2.zero; // sets the position of the item according to the slot
        productObj.name = productItem.Title; // sets the name of the gameObject


        // Instantiate the componentItems 

        int numberOfComp = craftToAdd.itemsID.Length -1;
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
            GameObject compSlot = Instantiate(craftSlot, recipeslt.transform.GetChild(1)); // creates the ComponentSlot of the Component panel of the recipeSlot
            GameObject compObj = Instantiate(craftItem, compSlot.transform); // creates the craftItem gameObject in the ComponentSlot of the component panel of the recipeSlot
            compObj.GetComponent<ItemData>().item = componentItem[i]; // sets the 
            compObj.GetComponent<Image>().sprite = componentItem[i].Sprite; // sets the sprite
            compObj.transform.localPosition = Vector2.zero; // sets the position of the item according to the slot
            compObj.name = componentItem[i].Title; // sets the name of the gameObject
            compSlot.GetComponentInChildren<Text>().text = componentAmount[i].ToString();
            compSlot.GetComponentInChildren<Text>().transform.SetAsLastSibling();

        }

        // Instantiate the create Button Function 

        Button button = recipeslt.transform.GetChild(2).GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            createObject(productID, productAmount, componentID, componentAmount);
        });
    }

    public void createObject(int productID, int productAmount, int[] componentID, int[] componentAmount)
    {

        Dictionary<Item, int> inventory = inventoryModel.inventory;

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

        if (isCreatable && inventoryController.canItFit(productID, productAmount))
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
        int ret = 0;
        Dictionary<Item, int> inventory = inventoryModel.inventory;
        foreach (Item key in inventory.Keys) // looking for the component in the inventory items List
        {

            if (key.id == id)
            {
                ret += inventory[key];
            }
        }

        Debug.Log("Wait" +id + " : " + ret);
        return ret;
    }
}
