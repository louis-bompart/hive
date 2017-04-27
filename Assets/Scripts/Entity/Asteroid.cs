using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory;
public class Asteroid : Entity
{
	public GameObject particlePrefab;

    #region Mineral id and count
    public int idMineral;
    public int count;


    #endregion
    private static InventoryController shipInventoryController;
    #region Minning
    protected override void endOfLife()
    {
        Debug.Log("Loot de :" + count + " item d'id :" + idMineral);
        for (int i = 0; i < count; i++)
        {
            shipInventoryController.AddItem(idMineral,1);
        }
        if(particlePrefab!= null)
        {
            GameObject Particle = Instantiate(particlePrefab, this.transform.position, Random.rotation);
            Particle.transform.localScale = this.transform.localScale;
            Destroy(Particle, 2);
        }
        FindObjectOfType<Data>().GetComponentInChildren<OtherStats>().DestroyedAsteroids++;
    }


    #endregion

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        if (shipInventoryController == null)
            shipInventoryController = new List<InventoryController>(GameObject.FindObjectsOfType<InventoryController>()).Find(x => x.inventoryType == InventoryController.Inventory.Ship);
        name = "Asteroid";
    }
}
