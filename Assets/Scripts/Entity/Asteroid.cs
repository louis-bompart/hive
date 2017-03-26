using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Entity {

    #region Mineral id and count
    public int idMineral;
    public int count;


    #endregion

    #region Minning
    protected override void endOfLife()
    {
        Debug.Log("Loot de :" + count + " item d'id :" + idMineral);
        for (int i = 0; i < count; i++)
        {
            inv.GetComponent<InventoryController>().AddItem(idMineral);
        }
    }


    #endregion

    private GameObject inv;

    // Use this for initialization
    protected override void Start () {
        base.Start();
        inv = GameObject.Find("Inventory");
    }
}
