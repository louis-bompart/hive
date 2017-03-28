using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRockForNeighborRule : RoomRule
{
    public NoRockForNeighborRule(Room self) : base(self)
    {
        constainedRooms.Add(Vector3.left);
        constainedRooms.Add(Vector3.right);
        constainedRooms.Add(Vector3.up);
        constainedRooms.Add(Vector3.down);
        constainedRooms.Add(Vector3.forward);
        constainedRooms.Add(Vector3.back);
    }

    public NoRockForNeighborRule(RoomRule rule, Room newSelf) : base(rule, newSelf)
    {
    }

    public override RoomRule GetCopy(Room room)
    {
        return new NoSameNeighborRule(this, room);
    }

    public override bool isAdmissible(Room other)
    {

        return !(other is RockRoom);
    }
}