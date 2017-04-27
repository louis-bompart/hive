using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoEnemiesForNeighborRule : RoomRule
{
    public NoEnemiesForNeighborRule(Room self) : base(self)
    {
        constainedRooms.Add(Vector3.left);
        constainedRooms.Add(Vector3.right);
        constainedRooms.Add(Vector3.up);
        constainedRooms.Add(Vector3.down);
        constainedRooms.Add(Vector3.forward);
        constainedRooms.Add(Vector3.back);
    }

    public NoEnemiesForNeighborRule(RoomRule rule, Room newSelf) : base(rule, newSelf)
    {
    }

    public override RoomRule GetCopy(Room room)
    {
        return new NoEnemiesForNeighborRule(this, room);
    }

    public override bool isAdmissible(Room other)
    {
        return !(other is IEnemyRoom);
    }
}