using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDictionay : MonoBehaviour {

    public TextAsset JSONDialogue;

	// Use this for initialization
	void Start () {
        DialogueDatabase.initDatabase(JSONDialogue);
	}
	

}
