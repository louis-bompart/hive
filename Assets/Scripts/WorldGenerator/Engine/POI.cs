using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POI : MonoBehaviour
{
    //int Seed { get; set; }
    public static GameObject prefab;
    public GameObject playerInSystemPrefab;
    public static GameObject playerInSystem;
    public LocalWorldGenerator world;
    public bool isCurrent;
    internal bool isAccessible;
    public string sceneName;

    public static POI Create(Vector3 position, string sceneName, bool isCurrent = false)
    {
        POI newPOI = Instantiate(prefab, position, Quaternion.identity).GetComponent<POI>();
        newPOI.sceneName = sceneName;
        newPOI.isCurrent = isCurrent;
        //Random.InitState(seed);
        //newPOI.x = Random.Range(-WorldGenerator.maxX, WorldGenerator.maxX);
        //newPOI.y = Random.Range(-WorldGenerator.maxY, WorldGenerator.maxY);
        return newPOI;
    }
    
    void Start()
    {
        if (isCurrent)
        {
            Instantiate(playerInSystemPrefab, transform.position, transform.rotation, transform);
            Camera.main.transform.position = transform.position + Vector3.up*100f; 
        }
    }

    private void OnMouseDown()
    {
        if (isAccessible)
        {
            FindObjectOfType<MapManager>().LoadScene(sceneName);
            //DO A TP
        }
    }
}