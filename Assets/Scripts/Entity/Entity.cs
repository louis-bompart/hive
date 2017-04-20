using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basic entity script, enable to take dommage and death of the entity
/// </summary>
public class Entity : MonoBehaviour
{


    #region health and death
    /// <summary>
    /// Only for inspector, use health for get set and operations
    /// </summary>
    public float _health;
    public float maxHP;
    public new string name;

    public float health
    {
        set
        {
            _health = value;
            if (_health <= 0)
            {
                OnKill();
            }
            if (_health >= maxHP)
            {
                _health = maxHP;
            }

        }
        get
        {
            return _health;
        }
    }


    public Material[] mats;
    public Color[] OriginalEmissionsColors;


    public IEnumerator hitColor()
    {


        int i = 0;
        foreach (Material mat in mats)
        {

            mat.SetColor("_EmissionColor", Color.red);
            i++;

        }
        yield return new WaitForSeconds(0.05f);
        int j = 0;
        foreach (Material mat in mats)
        {
            mat.SetColor("_EmissionColor", OriginalEmissionsColors[j]);
            j++;
        }
    }

    //Inflic domage to the entity, return if the entity is still alive
    public virtual bool takeDammage(int dammageIn)
    {
        StartCoroutine(hitColor());

        health -= dammageIn;
        //Debug.Log(health);
        if (health <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }

    }

    //Inflict damage to the entity, reducing the damage depending on the armor of the entity. Return true if entity is still alive.
    public virtual bool TakeArmorDamage(int damageIn, int armorStat)
    {
        StartCoroutine(hitColor());
        if (armorStat == 0)
        {
            health -= damageIn;
        }
        else
        {
            health -= damageIn / (7 - armorStat);
        }
        Debug.Log(health);
        if (health <= 0)
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
        if (maxHP == 0)
        {
            maxHP = _health;
        }
        mats = GetComponentInChildren<MeshRenderer>().materials;
        OriginalEmissionsColors = new Color[mats.Length];
        int i = 0;
        foreach (Material mat in mats)
        {
            OriginalEmissionsColors[i] = mat.GetColor("_EmissionColor");
            i++;
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }
}