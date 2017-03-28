using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardAsteroidFieldRoom : FieldRoom
{
    public HardAsteroidFieldRoom()
    {
    }

    public HardAsteroidFieldRoom(Room room, Vector3 position) : base(room, position) { }

    public override Room GetCopy(Vector3 position)
    {
        return new HardAsteroidFieldRoom(this, position);
    }
    protected override void Initialize()
    {
        base.Initialize();
        prefab = Resources.Load<GameObject>("WorldGenerators/Rooms/ProtoRooms/HardAsteroidField/Prefab");
    }
}