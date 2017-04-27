using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFormationRoom : RockRoom
{
    public RockFormationRoom()
    {
    }

    public RockFormationRoom(Room room, Vector3 position) : base(room, position) { }

    public override Room GetCopy(Vector3 position)
    {
        return new RockFormationRoom(this, position);
    }

    protected override void Initialize()
    {
        base.Initialize();
        prefab = Resources.Load<GameObject>("WorldGenerators/Rooms/ProtoRooms/RockFormationRoom/Prefab");
    }
}
