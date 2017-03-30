using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRoom : RockRoom
{
    public HeartRoom()
    {
    }

    public HeartRoom(Room room, Vector3 position) : base(room, position) { }

    public override Room GetCopy(Vector3 position)
    {
        return new HeartRoom(this, position);
    }

    protected override void Initialize()
    {
        base.Initialize();
        prefab = Resources.Load<GameObject>("WorldGenerators/Rooms/ProtoRooms/HeartRoom/Prefab");
    }
}
