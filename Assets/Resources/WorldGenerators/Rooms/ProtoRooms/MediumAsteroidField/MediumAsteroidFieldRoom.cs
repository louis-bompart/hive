using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumAsteroidFieldRoom : FieldRoom
{
    public MediumAsteroidFieldRoom()
    {
    }

    public MediumAsteroidFieldRoom(Room room, Vector3 position) : base(room, position) { }

    public override Room GetCopy(Vector3 position)
    {
        return new MediumAsteroidFieldRoom(this, position);
    }

    protected override void Initialize()
    {
        base.Initialize();
        prefab = Resources.Load<GameObject>("WorldGenerators/Rooms/ProtoRooms/MediumAsteroidField/Prefab");
    }
}