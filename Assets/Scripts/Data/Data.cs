using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    #region SingletonPatern
    private static Data _instance;

    public static Data instance
    {
        get
        {
            if(_instance==null)
            {
                Debug.Log("ForcedDataInitialisation");
                GameObject data = new GameObject("Data");
                data.AddComponent<Data>();
                _instance = data.GetComponent<Data>();
            }
            return _instance;
        }
    }

    #endregion

    #region Inventory Data
    //TODO

    #endregion

    #region Base Data
        
    #endregion

    private void initialise()
    {
        //Conservation of the new gameObject on load
        GameObject.DontDestroyOnLoad(gameObject);


    }

    public void Awake()
    {
        _instance = this;
        initialise();
    }


}
