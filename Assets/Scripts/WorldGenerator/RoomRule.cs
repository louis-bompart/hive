using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomRule
{
    private Room self;
    private List<Room> world;
    /// <summary>
    /// Add positions, relative to this room which are constrained by the enforcements of this rule
    /// </summary>
    private List<Vector3> constainedRooms;
    public IEnumerable<Vector3> GetConstrainedPositions() { return constainedRooms; }

    public RoomRule(Room self, ICollection<Room> world)
    {
        this.world = new List<Room>(world);
        this.self = self;
        this.constainedRooms = new List<Vector3>();
    }

    /// <summary>
    /// Check if the current rule is respected.
    /// </summary>
    /// <returns>True if respected, false if not</returns>
    public bool isAdmissible(Room other)
    {
        return true;
    }

    public bool isConstrained(Room other)
    {
        return !constainedRooms.Contains(other.position-self.position);
    }
}