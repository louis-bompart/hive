using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsGenerator : MonoBehaviour {

    public GameObject[] asteroids;
    private Vector3 origin = Vector3.zero;

    /// <summary>
    /// The minimum and maximum allowed size of an asteroid.
    /// </summary>
    public float minSize = 0.2f;
    public float maxSize = 1.5f;

    /// <summary>
    /// The minimum and maximum amount of asteroids.
    /// </summary>
    public int minCount = 500;
    public int maxCount = 1200;

    /// <summary>
    /// The minimum and maximum distance between asteroids.
    /// </summary>
    public float minDistance = 30.0f;
    public float maxDistance = 150.0f;
    void Start() {
        origin = transform.position;
        GenerateAsteroids(Random.Range(minCount, maxCount));
    }

    /// <summary>
    /// Generates a number (asteroidsCount) of asteroids with a random size between minSize and 
    /// maxSize and a random distance between them from minDistance to maxDistance.
    /// </summary>
    /// <param name="asteroidsCount">Number of Asteroids to Generate</param>
    public void GenerateAsteroids(int asteroidsCount) {
        for (int i = 0; i < asteroidsCount; i++) {
            float size = Random.Range(minSize, maxSize);
            GameObject prefab = asteroids[Random.Range(0, asteroids.Length)];
            Vector3 position = Vector3.zero;

            for (int j = 0; j < 100; j++) {
                position = Random.insideUnitSphere * (minDistance + (maxDistance - minDistance) * Random.value);
                position += origin;
                if (!Physics.CheckSphere(position, size / 2.0f)) {
                    break;
                }
            }
            GameObject go = Instantiate(prefab, position, Random.rotation);
            go.transform.localScale = new Vector3(size, size, size);
            setMineralAndCount(go);
            setMouvement(go);
        }
    }

    #region MineralCountSetter
    public int[] mineralCountProbability;
    private int[] mineralIdProbability = { 25, 40, 60, 75, 90, 100 };
    private int[] idMineral = { 100, 101, 102, 103, 104, 105 };

    

    private void setMineralAndCount(GameObject toSet)
    {
        Asteroid astToSet = toSet.GetComponent<Asteroid>();
        if(astToSet == null)
        {
            Debug.Log("Asteroid script not found");
            return;
        }
        

        //Set the mineral count
        int max = Mathf.Max(mineralCountProbability);
        int rand = (int)(Random.value * max);
        int i;
        for ( i = 0; i < mineralCountProbability.Length && rand > mineralCountProbability[i] ;i++)
        {
            
        }

        astToSet.count = i;

        //Set the mineral ID
        max = Mathf.Max(mineralIdProbability);
        rand = (int)(Random.value * max);
        for (i = 0; i < mineralIdProbability.Length && rand > mineralIdProbability[i]; i++)
        {

        }
        astToSet.idMineral = idMineral[i];


    }

    #endregion

    #region MovementSetter

    private Rigidbody rb;


    /// <summary>
    /// The minimum and maximum rotation speed allowed for an asteroid.
    /// </summary>
    public int minrSpeed = 1;
    public int maxrSpeed = 8;

    /// <summary>
    /// rxSpeed : rotation speed around x axis.
    /// rySpeed : rotation speed around y axis.
    /// rzSpeed : rotation speed around z axis.
    /// </summary>
    private int rxSpeed;
    private int rySpeed;
    private int rzSpeed;

    /// <summary>
    /// The minimum and maximum movement speed allowed for an asteroid.
    /// </summary>
    public int minmSpeed = 10;
    public int maxmSpeed = 200;

    /// <summary>
    /// mxSpeed : movement speed on x axis.
    /// mySpeed : movement speed on y axis.
    /// mzSpeed : movement speed on z axis.
    /// </summary>
    private int mxSpeed = 0;
    private int mySpeed = 0;
    private int mzSpeed = 0;


    /// <summary>
    /// Attribute the rotation and movement speed for the asteroid.
    /// Apply a force to the asteroid.
    /// </summary>
    private void setMouvement(GameObject toSet)
    {
        rb = toSet.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.Log("Rigibody not found on new asteroid");
            return;
        }


        mxSpeed = Random.Range(minmSpeed, maxmSpeed);
        mySpeed = Random.Range(minmSpeed, maxmSpeed);
        mzSpeed = Random.Range(minmSpeed, maxmSpeed);

        rxSpeed = Random.Range(minrSpeed, maxrSpeed);
        rySpeed = Random.Range(minrSpeed, maxrSpeed);
        rzSpeed = Random.Range(minrSpeed, maxrSpeed);

        Vector3 movement = new Vector3(mxSpeed, mySpeed, mzSpeed);
        rb.AddForce(movement);

        Vector3 rotation = new Vector3(rxSpeed, rySpeed, rzSpeed);
        rb.AddTorque(rotation);
    }
    #endregion


}
