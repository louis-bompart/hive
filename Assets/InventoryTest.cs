using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTest : MonoBehaviour {


    public InventoryController inventoryController;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddItem()
    {
        inventoryController.AddItem(200, 5);
        inventoryController.AddItem(201, 3);
        inventoryController.AddItem(202, 3);

        inventoryController.AddItem(210, 3);
        inventoryController.AddItem(211, 3);
        inventoryController.AddItem(212, 3);
    }
}
