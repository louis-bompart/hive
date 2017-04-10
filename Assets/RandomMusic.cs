using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMusic : MonoBehaviour {

    public List<AudioClip> Musics;

    private AudioSource source;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();

        if(Musics.Count >=1)
        {
            source.clip = Musics[Random.Range(0, Musics.Count)];
        }
        source.Play();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
