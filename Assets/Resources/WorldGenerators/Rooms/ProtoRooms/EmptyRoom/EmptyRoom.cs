using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyRoom : Room
{
    public EmptyRoom()
    {
        canBeFirst = true;
    }

    public EmptyRoom(Room room, Vector3 position) : base(room, position) { }

    public override Room GetCopy(Vector3 position)
    {
        return new EmptyRoom(this, position);
    }

    protected override void Initialize()
    {
        base.Initialize();
        rules.Add(new NoEnemiesForNeighborRule(this));
        prefab = Resources.Load<GameObject>("WorldGenerators/Rooms/ProtoRooms/EmptyRoom/Prefab");
    }
}