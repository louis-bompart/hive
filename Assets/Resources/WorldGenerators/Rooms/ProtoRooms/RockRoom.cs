using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockRoom : Room
{
    public RockRoom()
    {
    }

    public RockRoom(Room room, Vector3 position) : base(room, position) { }

    public override Room GetCopy(Vector3 position)
    {
        return new RockRoom(this, position);
    }

    protected override void Initialize()
    {
        base.Initialize();
        rules.Add(new NoRockForNeighborRule(this));
    }
}