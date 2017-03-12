using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AC3
{
    public static void Execute(ref Dictionary<Vector3, List<Room>> csp)
    {
        Queue<Arc> queue = GenerateArcsQueue(csp);
        while (queue.Count > 0)
        {
            Arc arc = queue.Dequeue();
            if (RemoveInconsistentValues(arc, ref csp))
            {
                foreach (Arc neighbor in GetNeighbors(csp, arc.roomI[0].position))
                {
                    queue.Enqueue(neighbor.GetReverseArc());
                }
            }
        }
    }

    private static bool RemoveInconsistentValues(Arc arc, ref Dictionary<Vector3, List<Room>> csp)
    {
        bool removed = false;
        foreach (Room room in arc.roomI)
        {
            if (!isConstraintCompliant(room, arc.roomJ))
            {
                arc.roomI.Remove(room);
                csp[room.position].Remove(room);
                removed = true;
            }
        }
        return removed;
    }

    private static bool isConstraintCompliant(Room room, List<Room> roomJ)
    {
        foreach (Room candidate in roomJ)
        {
            foreach (RoomRule rule in room.rules)
            {
                if (rule.isConstrained(candidate))
                {
                    if (!rule.isAdmissible(candidate))
                    {
                        roomJ.Remove(candidate);
                    }
                }
            }
        }
        return roomJ.Count > 0;
    }

    private static Queue<Arc> GenerateArcsQueue(Dictionary<Vector3, List<Room>> csp)
    {
        Queue<Arc> arcs = new Queue<Arc>();
        foreach (Vector3 variable in csp.Keys)
        {
            List<List<Room>> neighbors = new List<List<Room>>();

            Queue<Arc> tmp = GetNeighbors(csp, variable);
            foreach (Arc arc in tmp)
            {
                arcs.Enqueue(arc);
            }
        }
        return arcs;
    }

    public static Queue<Arc> GetNeighbors(Dictionary<Vector3, List<Room>> csp, Vector3 variable)
    {
        Queue<Arc> output = new Queue<Arc>();
        foreach (Room room in csp[variable])
        {
            foreach (RoomRule rule in room.rules)
            {
                foreach (Vector3 neigborPosition in rule.GetConstrainedPositions())
                {
                    List<Room> neighbor = new List<Room>();
                    if (csp.TryGetValue(neigborPosition, out neighbor))
                    {
                        output.Enqueue(new Arc(csp[variable], neighbor));
                    }
                }
            }
        }
        return output;
    }
}
