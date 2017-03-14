﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LWG1 : LocalWorldGenerator
{
    protected override void InitializeRoomList()
    {
        this.rooms = new List<Room>();
        rooms.Add(new BlueRoom());
        rooms.Add(new RedRoom());
        rooms.Add(new GreenRoom());
    }

    //private void Start()
    //{
    //    foreach (Vector3 key in localWorld.Keys)
    //    {
    //        Instantiate(localWorld[key].prefab, key, localWorld[key].prefab.transform.rotation, transform.parent);
    //    }
    //}
}
