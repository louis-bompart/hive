using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {

    public DialogueBox box;
    private static DialogueManager _instance;

    public static DialogueManager instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.Log("not good");
                GameObject temp = new GameObject("DialogueManager");
                _instance = temp.AddComponent<DialogueManager>();
            }
            return _instance;
        }
    }

    public void Start()
    {
        _instance = this;
    }
	
    public void lauchDialogue(string inText,float prontTime = -1)
    {
        box.prontNewText(inText, prontTime);
    }
}
