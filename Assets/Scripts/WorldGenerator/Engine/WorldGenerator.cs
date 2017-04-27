//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public int seed;
    public int maxPOI;
    public float xSize;
    public float ySize;
    public GameObject POIPrefab;
    public static float maxX;
    public static float maxY;
    public bool randomizeSeed;
    private int nbOfPOI;
    [SerializeField]
    public Dictionary<Vector3, string> positions;
    private Vector3 barycenter;
    private float variance;
    public Vector3 current;
    public static WorldGenerator instance;

    private Vector3 last = Vector3.zero;
    internal bool isReady;
    public int minPOI;

    // Use this for initialization
    private void Awake()
    {
        positions = new Dictionary<Vector3, string>();
        if (FindObjectsOfType<WorldGenerator>().Length > 1)
            Destroy(this);
        else
        {
            instance = this;
            Generate();
            DontDestroyOnLoad(gameObject);
        }
    }
    void Generate()
    {
        isReady = false;
        POI.prefab = POIPrefab;
        maxX = xSize;
        maxY = ySize;
        //Init to 0 because it's 0 for 1 pts
        variance = 0f;
        //POIs = new List<POI>();
        if (randomizeSeed)
        {
            seed = Random.Range(0, int.MaxValue);
        }
        Random.InitState(seed);
        nbOfPOI = Random.Range(minPOI, maxPOI);
        //nbOfPOI = maxPOI;
        //ToDo Init starbase
        //blabla don't forget to set barycenter as the pos of the starbase
        for (int i = 0; i < nbOfPOI; i++)
        {
            /*POI newPOI = */
            Vector3 newVector = last;
            Vector3 direction = ((barycenter - newVector).normalized + new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f))).normalized;
            direction *= Random.Range(3f, maxX);
            newVector += direction;
            positions.Add(newVector, i == 0 ? "Release" : "LittleAsteroidField");
            if (i == 0)
            {
                current = newVector;
            }
            last = newVector;
            UpdateBarycenter();
            UpdateVariance();
        }
        isReady = true;
    }

    private void UpdateBarycenter()
    {
        barycenter *= positions.Count - 1;
        barycenter += last;
        barycenter /= (float)positions.Count;

        /* Useless test, vector3 never == null
         if (barycenter != null)
        {
            barycenter *= positions.Count - 1;
            barycenter += last;
            barycenter /= (float)positions.Count;
        }
        else
        {
            barycenter = positions.Keys.GetEnumerator().Current;
        }*/
    }

    private void UpdateVariance()
    {
        variance = 0;
        foreach (Vector3 vect in positions.Keys)
        {

            variance += (vect - barycenter).sqrMagnitude;
        }
        variance /= (float)positions.Count;
    }
    public void TakeCurrent(POI poi)
    {
        current = poi.transform.position;
    }
    // Update is called once per frame
    void Update()
    {


    }
}
