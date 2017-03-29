using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRockRoom : RockRoom
{
    public BigRockRoom()
    {
    }

    public BigRockRoom(Room room, Vector3 position) : base(room, position) { }

    public override Room GetCopy(Vector3 position)
    {
        return new BigRockRoom(this, position);
    }

    protected override void Initialize()
    {
        base.Initialize();
        rules.Add(new NoNearCenterRule(this));
        prefab = Resources.Load<GameObject>("WorldGenerators/Rooms/ProtoRooms/BigRockRoom/Prefab");
    }
}
