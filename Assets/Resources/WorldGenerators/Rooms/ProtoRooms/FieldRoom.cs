using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldRoom : Room
{
    public FieldRoom()
    {
    }

    public FieldRoom(Room room, Vector3 position) : base(room, position) { }

    public override Room GetCopy(Vector3 position)
    {
        return new FieldRoom(this, position);
    }

    protected override void Initialize()
    {
        base.Initialize();
    }
}