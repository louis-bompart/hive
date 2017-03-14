using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class LocalWorldGenerator : MonoBehaviour
{
    //ToDo put to static when worldgenerators'll be read from Resources
    public static List<LocalWorldGenerator> worldGenerators;
    public static LocalWorldGenerator Create(int seed)
    {
        if (worldGenerators == null)
        {
            LoadGenerators();
        }

        UnityEngine.Random.InitState(seed);
        LocalWorldGenerator newLWG = Instantiate<LocalWorldGenerator>(worldGenerators[UnityEngine.Random.Range(1, worldGenerators.Count) - 1]);
        newLWG.radius = UnityEngine.Random.Range(newLWG.localMinRadius, newLWG.localMaxRadius);
        UnityEngine.Random.InitState(seed);
        Room firstRoom = null;
        newLWG.InitializeRoomList();
        List<Room> copyRooms = new List<Room>(newLWG.rooms);
        while (firstRoom == null && copyRooms.Count > 0)
        {
            int index = UnityEngine.Random.Range(1, copyRooms.Count) - 1;
            firstRoom = copyRooms[index].canBeFirst ? copyRooms[index] : null;
        }
        if (firstRoom == null)
        {
            Debug.LogError("No suitable room for generation begin exists in this generator !");
        }
        else
        {
            firstRoom.position = Vector3.zero;
            firstRoom.distanceFromCenter = 0;

            newLWG.localWorld = new Dictionary<Vector3, Room>();
            newLWG.localWorld.Add(Vector3.zero, firstRoom);
            newLWG.GenerateCSP();
            newLWG.BacktrackingSearch();
        }
        return newLWG;
    }

    private static void LoadGenerators()
    {

        worldGenerators = new List<LocalWorldGenerator>(Resources.Load<GameObject>("WorldGenerators/LWGList").GetComponent<LWGList>().list);
    }

    private bool BacktrackingSearch()
    {
        Dictionary<Vector3, List<Room>> result = RecursiveBacktracking(new Dictionary<Vector3, List<Room>>(), csp);
        if (result.Count > 0)
        {
            foreach (Vector3 key in result.Keys)
            {
                localWorld.Add(key, result[key][0]);
            }
            return true;
        }
        return false;
    }

    private Dictionary<Vector3, List<Room>> RecursiveBacktracking(Dictionary<Vector3, List<Room>> assignment, Dictionary<Vector3, List<Room>> csp)
    {
        AC3.Execute(ref csp);
        if (CheckAssignment(assignment))
        {
            return assignment;
        }
        if (HasNullValue(csp))
        {
            return new Dictionary<Vector3, List<Room>>();
        }
        Vector3 variable = SelectUnassignedVariable();
        if (variable == Vector3.zero)
        {
            Debug.Log("No variable found during the recursivebacktracking");
            return new Dictionary<Vector3, List<Room>>();
        }
        IEnumerable<Room> sortedUnassignedValues = OrderDomainValues(csp[variable]);
        foreach (Room value in sortedUnassignedValues)
        {
            //Consistent thanks to AC3
            if (!assignment.ContainsKey(variable))
                assignment.Add(variable, new List<Room>());
            assignment[variable].Add(value);
            List<Room> tmp = new List<Room>(csp[variable]);
            csp[variable].Clear();
            csp[variable].Add(value);
            Dictionary<Vector3, List<Room>> result = RecursiveBacktracking(assignment, csp);
            if (result.Count > 0)
            {
                return result;
            }
            assignment[variable].Remove(value);
            csp[variable] = tmp;
        }
        return new Dictionary<Vector3, List<Room>>();
    }

    private bool HasNullValue(Dictionary<Vector3, List<Room>> csp)
    {
        foreach (List<Room> item in csp.Values)
        {
            if (item.Count < 1)
                return true;
        }
        return false;
    }

    private IEnumerable<Room> OrderDomainValues(List<Room> list)
    {
        return list.ToArray().OrderBy(room => AC3.GetNeighbors(csp, room.position).Count);
    }

    private bool CheckAssignment(Dictionary<Vector3, List<Room>> assignment)
    {
        //Minus 1 due to the center which is already assigned.
        if (assignment.Count != csp.Count - 1)
        {
            return false;
        }
        foreach (List<Room> room in assignment.Values)
        {
            if (room.Count != 1)
                return false;
        }
        return true;
    }

    private Vector3 SelectUnassignedVariable()
    {
        List<Vector3> selectedKeys = new List<Vector3>();
        int maxValCount = int.MaxValue;
        foreach (Vector3 key in csp.Keys)
        {
            if (csp[key].Count <= maxValCount && csp[key].Count > 1)
            {
                if (csp[key].Count < maxValCount)
                    selectedKeys.Clear();
                selectedKeys.Add(key);
                maxValCount = csp[key].Count;
            }
        }
        Vector3 selectedKey = Vector3.zero;
        int maxConstraintCount = int.MinValue;
        foreach (Vector3 key in selectedKeys)
        {
            int nbConstraint = AC3.GetNeighbors(csp, key).Count;
            if (nbConstraint > maxConstraintCount)
            {
                selectedKey = key;
                maxConstraintCount = nbConstraint;
            }

        }
        return selectedKey;
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
                    if (Vector3.Distance(Vector3.zero, currentPos) <= radius && (i != 0 || j != 0 || k != 0))
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
            rooms.Add(room.GetCopy(atPosition));
        }
        return rooms;
    }

    public int localMaxRadius;
    public int localMinRadius;
    public int radius;
    public List<Room> rooms;
    public Dictionary<Vector3, Room> localWorld;
    public Dictionary<Vector3, List<Room>> csp;

    protected abstract void InitializeRoomList();
}