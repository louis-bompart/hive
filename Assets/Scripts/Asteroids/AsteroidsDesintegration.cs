using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsDesintegration : MonoBehaviour {

	/// <summary>
	/// The health of the asteroid.
	/// </summary>
	public float health = 100f;

	/// <summary>
	/// The asteroids particules explosion prefab.
	/// particuleSize : size of the particules
	/// </summary>

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
		Debug.Log ("You collected " + asm.mineralCount + " minerals");
        Destroy(this.gameObject);
    }


}
