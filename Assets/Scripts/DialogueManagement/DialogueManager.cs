using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {

    public DialogueBox box;
    private static DialogueManager _instance;

    List<DialogueDataItem> toLaunch;

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
        toLaunch = new List<DialogueDataItem>();
    }
	
    public void Update()
    {
        if(toLaunch.Count >0 &&  box.isActiveAndEnabled == false )
        {
            DialogueDataItem t = toLaunch[0];
            toLaunch.RemoveAt(0);
            box.prontNewText(t.Text,t.displayTime);
        }
    }

    public void lauchDialogue(string inText,float prontTime = -1)
    {
        lauchDialogue(new DialogueDataItem("null", inText, prontTime));
    }

    public void lauchDialogue(DialogueDataItem inD)
    {
        inD.Text = inD.Text.Replace("\n", System.Environment.NewLine);
        toLaunch.Add(inD);
    }
}
