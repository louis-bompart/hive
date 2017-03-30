using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {

	/// <summary>
	/// The item the tooltip is linked to.
	/// </summary>
	private Item item;

	/// <summary>
	/// The text of the tooltip.
	/// </summary>
	private string data;
	public GameObject tooltip;

	void Start(){
		tooltip = GameObject.Find ("Tooltip");
		tooltip.SetActive (false);
	}

	/// <summary>
	/// the tooltip follows the mouse Position.
	/// </summary>
	void Update(){
		if (tooltip.activeSelf) {
			tooltip.transform.position = Input.mousePosition;
		}
	}

	/// <summary>
	/// Activate the tooltip of the specified item
	/// </summary>
	/// <param name="item">Item.</param>
	public void Activate(Item item){
		this.item = item;
		ConstructDataString ();
		tooltip.SetActive (true);
	}

	/// <summary>
	/// Deactivate the tooltip
	/// </summary>
	public void Deactivate(){
		tooltip.SetActive (false);
	}

	/// <summary>
	/// Constructs the data string according to the item.
	/// </summary>
	public void ConstructDataString(){
		data = "<color=#0473f0><b>" + item.Title + "</b></color>\n"+ item.Description;
		tooltip.transform.GetChild (0).GetComponent<Text> ().text = data;
	}
}
