using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Stub not complete at all
/// </summary>
public class InventoryTest : MonoBehaviour {

    public Inventory inventory;
	// Use this for initialization
	void Start () {
        inventory.AddItem(0);
        inventory.AddItem(0);
        inventory.AddItem(1);
        inventory.AddItem(1);
        inventory.AddItem(1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
