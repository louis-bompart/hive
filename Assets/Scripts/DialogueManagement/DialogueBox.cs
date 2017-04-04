using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour {

    public Text textZone;
    public float prontTime;


    public string toPront;
    private float actualTime;
    private float startPront;



	// Use this for initialization
	void Start () {
        startPront = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
        actualTime = Time.realtimeSinceStartup - startPront;
        updateText();
	}

    public void test()
    {
        Debug.Log("Test");
    }

    public void prontNewText(string text, float newProntTime = -1)
    {
        if(newProntTime >= 0)
        {
            prontTime = newProntTime;
        }
        startPront = Time.realtimeSinceStartup;
        toPront = text;
        updateText();
        prontBox();
    }

    private void updateText()
    {
        string textToPront;
        if(prontTime > 0)
        {
            float percent = actualTime / prontTime;
            if(percent >= 1)
            {
                textToPront = toPront;
            }
            else
            {
                int nbChar = toPront.Length;
                int nbCharToPront = (int)(nbChar * percent);
                if(nbCharToPront>=toPront.Length)
                {
                    textToPront = toPront;
                }
                else
                {
                    textToPront = toPront.Substring(0, nbCharToPront);
                }
            }
        }
        else
        {
            textToPront = toPront;
        }

        textZone.text = textToPront;
    }


    public void prontBox()
    {
        OptionMenuClick.PauseGame();
        gameObject.SetActive(true);
    }

    public void validate()
    {
        OptionMenuClick.UnPauseGame();
        gameObject.SetActive(false);
    }

}
