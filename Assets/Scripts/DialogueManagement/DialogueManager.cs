using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {

    public DialogueBox box;
    private static DialogueManager _instance;

    List<DialogueDataItem> toLaunch;
    AudioSource audiSrc;

    public static DialogueManager instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.Log("not good: No instance of dialogue manager found");
            }
            return _instance;
        }
    }

    public void Start()
    {
        _instance = this;
        toLaunch = new List<DialogueDataItem>();
        audiSrc = GetComponent<AudioSource>();
    }
	
    public void Update()
    {
        if(toLaunch.Count >0 &&  box.isActiveAndEnabled == false )
        {
            nextDialogue();
        }
    }

    public void lauchDialogue(string inText,float prontTime = -1)
    {
        lauchDialogue(new DialogueDataItem("null", inText, prontTime,""));
    }

    public void lauchDialogue(DialogueDataItem inD)
    {
        if(inD != null)
        {
            Debug.Log(inD.ClipAudio);
            inD.Text = inD.Text.Replace("\n", System.Environment.NewLine);
            toLaunch.Add(inD);
        }
    }

    private void nextDialogue( )
    {
        DialogueDataItem t = toLaunch[0];
        toLaunch.RemoveAt(0);
        box.prontNewText(t.Text, t.displayTime);
        if(t.ClipAudio != null && audiSrc != null)
        {
            AudioClip newClip = Resources.Load<AudioClip>("Dialogue/AudioClip/" + t.ClipAudio);
            if(newClip != null)
            {
                audiSrc.clip = newClip;
                audiSrc.Play();
            }
        }
    }
}
