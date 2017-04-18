using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{

    public Dictionary<Vector3, string> positions;
    private bool generationDone;
    Vector3 current;
    // Use this for initialization
    void Start()
    {
        generationDone = false;
        //WorldGenerator worldGenerator = FindObjectOfType<WorldGenerator>();
        positions = WorldGenerator.instance.positions;
        current = WorldGenerator.instance.current;
        DoIT();
    }

    // Update is called once per frame
    void DoIT()
    {
        //if (!generationDone && WorldGenerator.instance.isReady)
        {
            generationDone = true;
            foreach (Vector3 position in positions.Keys)
            {
                POI.Create(position, positions[position], position == current);
            }
        }
    }
}
