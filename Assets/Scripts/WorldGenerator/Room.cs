using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    public bool canBeFirst;
    public GameObject prefab;
    public Vector3 position;
    public float distanceFromCenter;
    public List<RoomRule> rules;
    private Room room;

    public Room() : this(Vector3.zero)
    {

    }

    public Room(Vector3 position)
    {
        this.position = position;
    }

    public Room(Room room) : this(room,room.position) { }

    public Room(Room room, Vector3 position)
    {
        this.canBeFirst = room.canBeFirst;
        this.prefab = room.prefab;
        this.position = position;
        this.distanceFromCenter = Vector3.Distance(Vector3.zero, position);
        this.rules = room.rules;
    }
}