using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class BackButton : MonoBehaviour, IPointerEnterHandler{

    public AudioClip hoverSoundEffect;
    public AudioClip clickSoundEffect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick() {
        StartCoroutine(PlaySoundAndLoadScene());
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = hoverSoundEffect;
        audio.Play();
    }

    IEnumerator PlaySoundAndLoadScene()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickSoundEffect;
        audio.Play();
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);

        SceneManager.LoadScene("Main Menu");

    }
}
