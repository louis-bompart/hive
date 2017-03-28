using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesRockRoom : RockRoom, IEnemyRoom
{
    public EnemiesRockRoom()
    {
    }

    public EnemiesRockRoom(Room room, Vector3 position) : base(room, position) { }

    public override Room GetCopy(Vector3 position)
    {
        return new RichAsteroidFieldRoom(this, position);
    }

    protected override void Initialize()
    {
        base.Initialize();
        rules.Add(new NoNearCenterRule(this));
        prefab = Resources.Load<GameObject>("WorldGenerators/Rooms/ProtoRooms/RichAsteroidFieldRoom/Prefab");
    }
}