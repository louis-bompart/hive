using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudiManager : MonoBehaviour {
    public List<AudioClip> SpaceMusics;
    public AudioClip baseMusique;
    bool inBase;

    private AudioSource source;
    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();

        if(testInBase())
        {
            launchBaseMusique();
            inBase = true;
        }
        else
        {
            lauchSpaceMusique();
            inBase = false;
        }
    }
	
	
    
    // Update is called once per frame
	void Update () {
	    if(!inBase && testInBase())
        {
            inBase = true;
            launchBaseMusique();
            Debug.Log("inBase");
        }
        else if(inBase && !testInBase())
        {
            inBase = false;
            lauchSpaceMusique();
            Debug.Log("inSpace");
        }
	}

    void launchBaseMusique()
    {
        source.clip = baseMusique;
        source.Play();
    }

    void lauchSpaceMusique()
    {
        if (SpaceMusics.Count >= 1)
        {
            source.clip = SpaceMusics[Random.Range(0, SpaceMusics.Count)];
        }
        source.Play();
    }

    bool testInBase()
    {
        return (SceneManager.GetActiveScene().name == "Bridge" || SceneManager.GetActiveScene().name == "Factory" || SceneManager.GetActiveScene().name == "StorageBay" || SceneManager.GetActiveScene().name == "Hangar");
    }
}
