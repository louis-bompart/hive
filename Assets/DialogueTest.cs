using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTest : MonoBehaviour {

    private float delay = 5;
    private bool played = false;

	// Update is called once per frame
	void Update () {
        if(Time.realtimeSinceStartup >= delay && played == false)
        {
            played = true;
            DialogueManager.instance.lauchDialogue("Hello here! I am a rainbow unicorn that just make some tests to see if all work fine");
        }
	}
}
