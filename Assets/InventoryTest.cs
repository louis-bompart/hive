using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTest : MonoBehaviour {


    public InventoryController invCtrl;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddItem()
    {
        invCtrl.AddItem(0, 5);
        invCtrl.AddItem(1, 5);
    }
}
