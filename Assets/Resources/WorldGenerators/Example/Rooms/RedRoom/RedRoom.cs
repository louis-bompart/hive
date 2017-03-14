using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedRoom : Room
{
    public RedRoom()
    {
    }

    public RedRoom(Room room, Vector3 position) : base(room, position) { }

    protected override void Initialize()
    {
        base.Initialize();
        rules.Add(new NoSameNeighborRule(this));
        prefab = Resources.Load<GameObject>("WorldGenerators/Example/Rooms/RedRoom.prefab");
    }

    public override Room GetCopy(Vector3 position)
    {
        return new RedRoom(this, position);
    }
}