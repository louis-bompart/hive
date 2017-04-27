using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class POI : MonoBehaviour
{
    //int Seed { get; set; }
    public static GameObject prefab;
    public GameObject playerInSystemPrefab;
    public static GameObject playerInSystem;
    public LocalWorldGenerator world;
    public GameObject[] models;
    public static POI current;
    public bool isCurrent;
    internal bool isAccessible;
    public string sceneName;

    public static POI Create(Vector3 position, string sceneName, bool isCurrent = false)
    {
        POI newPOI = Instantiate(prefab, position, Quaternion.identity).GetComponent<POI>();
        newPOI.sceneName = sceneName;
        switch (sceneName)
        {
            case "Release":
                Instantiate(newPOI.models[0], newPOI.transform.position, newPOI.transform.rotation, newPOI.transform);
                break;
            case "LittleAsteroidField":
                Instantiate(newPOI.models[1], newPOI.transform.position, newPOI.transform.rotation, newPOI.transform);
                break;
            default:
                break;
        }
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
            current = this;
            Camera.main.transform.position = transform.position + Vector3.up * 100f;
        }
    }

    private void OnMouseDown()
    {
        if (isAccessible)
        {
            current.isCurrent = false;
            isCurrent = true;
            current = this;
            WorldGenerator.instance.TakeCurrent(this);
            FindObjectOfType<MapManager>().LoadScene(sceneName);
            //DO A TP
        }
    }
}