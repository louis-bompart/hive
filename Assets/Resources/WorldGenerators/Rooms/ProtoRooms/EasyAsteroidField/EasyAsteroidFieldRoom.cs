using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyAsteroidFieldRoom : FieldRoom
{
    public EasyAsteroidFieldRoom()
    {
    }

    public EasyAsteroidFieldRoom(Room room, Vector3 position) : base(room, position) { }

    public override Room GetCopy(Vector3 position)
    {
        return new EasyAsteroidFieldRoom(this, position);
    }

    protected override void Initialize()
    {
        base.Initialize();
        prefab = Resources.Load<GameObject>("WorldGenerators/Rooms/ProtoRooms/EasyAsteroidField/Prefab");
    }
}