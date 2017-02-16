using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsDesintegration : MonoBehaviour {

	/// <summary>
	/// The health of the asteroid.
	/// </summary>
	public float health = 100f;

    private GameObject inv;

    void Start()
    {
        inv = GameObject.Find("Inventory");
    }

    /// <summary>
    /// Desintegrates it if its health goes below 0
    /// </summary>
    void Update(){
		if (health <= 0f) {
			desintegrate ();
        }
	}

	/// <summary>
	/// Tells how many minerals you collect, create particules,
	/// destroy the asteroid
	/// </summary>
	public void desintegrate(){
		AsteroidsMineral asm = this.gameObject.GetComponent <AsteroidsMineral>();
        if(asm != null)
        {
            for (int i = 0; i < asm.mineralCount; i++)
            {
                inv.GetComponent<Inventory>().AddItem(asm.id);
            }
        }

        Destroy(this.gameObject);
    }


}
