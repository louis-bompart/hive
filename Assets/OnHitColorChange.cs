using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnHitColorChange : MonoBehaviour {


    public Color originalColor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnHit() {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        StartCoroutine(ChangeColor());
    }

    public IEnumerator ChangeColor()
    {
        GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Image>().color = originalColor;
    }
}
