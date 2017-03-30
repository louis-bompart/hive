using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LWG2 : LocalWorldGenerator
{
    protected override void InitializeRoomList()
    {
        this.rooms = new List<Room>();

        rooms.Add(new EmptyRoom());

        //rooms.Add(new BigRockRoom());
        rooms.Add(new HeartRoom());
        rooms.Add(new RockFormationRoom());
        rooms.Add(new EnemiesRockRoom());

        rooms.Add(new EasyAsteroidFieldRoom());
        rooms.Add(new HardAsteroidFieldRoom());
        rooms.Add(new MediumAsteroidFieldRoom());
        //rooms.Add(new RichAsteroidFieldRoom());
    }

    private void Start()
    {
       // roomSize = 25f;
        foreach (Vector3 key in localWorld.Keys)
        {
            Instantiate(localWorld[key].prefab, key * roomSize, localWorld[key].prefab.transform.rotation, transform.parent);
        }
        Debug.Log("A World of " + localWorld.Count + " cases has been generated in " + Time.realtimeSinceStartup + "s.");
    }
}
