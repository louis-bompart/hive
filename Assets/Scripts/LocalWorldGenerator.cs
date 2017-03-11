using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalWorldGenerator : MonoBehaviour
{
    public static List<LocalWorldGenerator> worldGenerators;
    public static LocalWorldGenerator Create(int seed)
    {
        UnityEngine.Random.InitState(seed);
        LocalWorldGenerator newLWG = Instantiate<LocalWorldGenerator>(worldGenerators[UnityEngine.Random.Range(0, worldGenerators.Count) - 1]);
        newLWG.radius = UnityEngine.Random.Range(newLWG.localMinRadius, newLWG.localMaxRadius);
        UnityEngine.Random.InitState(seed);
        Room firstRoom = null;
        List<Room> copyRooms = new List<Room>(newLWG.rooms);
        while (firstRoom == null && copyRooms.Count > 0)
        {
            int index = UnityEngine.Random.Range(0, copyRooms.Count) - 1;
            firstRoom = copyRooms[index].canBeFirst ? copyRooms[index] : null;
        }
        if (firstRoom == null)
        {
            Debug.LogError("No suitable room for generation begin exists in this generator !");
        }
        else
        {
            newLWG.localWorld.Add(Vector3.zero, firstRoom);
            newLWG.GenerateCSP();
            AC3(ref newLWG.csp);
        }
        return newLWG;
    }

    private static void AC3(ref Dictionary<Vector3, List<Room>> csp)
    {
        Queue<Arc> queue = GenerateArcsQueue(csp);
        while (queue.Count > 0)
        {
            Arc arc = queue.Dequeue();
            if (RemoveInconsistentValues(arc))
            {
                foreach (Arc neighbor in GetNeighbors(csp, arc.roomI[0].position))
                {
                    queue.Enqueue(neighbor.GetReverseArc());
                }
            }
        }
        throw new NotImplementedException();
    }

    private static bool RemoveInconsistentValues(Arc arc)
    {
        bool removed = false;
        foreach (Room room in arc.roomI)
        {
            if (!isConstraintCompliant(room, arc.roomJ))
            {
                arc.roomI.Remove(room);
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

    private static Queue<Arc> GetNeighbors(Dictionary<Vector3, List<Room>> csp, Vector3 variable)
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

    private void GenerateCSP()
    {
        csp = new Dictionary<Vector3, List<Room>>();
        List<Room> tmp = new List<Room>();
        tmp.Add(localWorld[Vector3.zero]);
        csp.Add(Vector3.zero, tmp);
        for (int i = 0; i < radius; i++)
        {
            for (int j = 0; j < radius; j++)
            {
                for (int k = 0; k < radius; k++)
                {
                    Vector3 currentPos = new Vector3(i, j, k);
                    if (Vector3.Distance(Vector3.zero, currentPos) <= radius && i != 0 && j != 0 && k != 0)
                    {
                        tmp = generateRoomsCopy(currentPos);
                        csp.Add(currentPos, tmp);
                    }
                }
            }
        }
    }

    private List<Room> generateRoomsCopy(Vector3 atPosition)
    {
        List<Room> rooms = new List<Room>();
        foreach (Room room in this.rooms)
        {
            rooms.Add(new Room(room, atPosition));
        }
        return rooms;
    }

    public float localMaxRadius;
    public float localMinRadius;
    public float radius;
    public List<Room> rooms;
    public Dictionary<Vector3, Room> localWorld;
    public Dictionary<Vector3, List<Room>> csp;
}