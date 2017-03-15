using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basic entity script, enable to take dommage and death of the entity
/// </summary>
public class Entity : MonoBehaviour {


    #region health and death
    /// <summary>
    /// Only for inspector, use health for get set and operations
    /// </summary>
    public int _health;

    public int health
    {
        set
        {
            _health = value;
            if(_health<=0)
            {
                OnKill();
            }
            
        }
        get
        {
            return _health;
        }
    }


    IEnumerator hitColor() {

        Material[] mats = GetComponentInChildren<MeshRenderer>().materials;
        Color[] EmissionsColors = new Color[mats.Length];
        int i = 0;
        foreach (Material mat in mats)
        {
            EmissionsColors[i] = mat.GetColor("_EmissionColor");
            i++;
            mat.SetColor("_EmissionColor", Color.red);

        }
        yield return new WaitForSeconds(0.05f);
        int j = 0;
        foreach (Material mat in mats)
        {
            mat.SetColor("_EmissionColor", EmissionsColors[j]);
            j++;
        }
    }

    //Inflic domage to the entity, return if the entity is still alive
    public bool takeDammage(int dammageIn)
    {
        StartCoroutine(hitColor());

        health -= dammageIn;
        if(health<=0)
        {
            return false;
        }
        else
        {
            return true;
        }
       
    }

    /// <summary>
    /// Called when health reach 0
    /// Shouldn't be overide
    /// </summary>
    private void OnKill()
    {
        endOfLife();
        Destroy(gameObject);
    }

    /// <summary>
    /// Called when health reach 0 but before the gameobject is destroyed
    /// Can be overide
    /// </summary>
    protected virtual void endOfLife()
    {
       
    }
    #endregion


    // Use this for initialization
    protected virtual void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }
}
