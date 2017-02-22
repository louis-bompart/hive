using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFlightControl {

    Enemy parent;

    public BasicFlightControl(Enemy parentIn)
    {
        parent = parentIn;
    }

    /// <summary>
    /// Comptute to form the desired force for the next frame
    /// </summary>
    /// <returns></returns>
    public Vector3 CalculateForces()
    {
        return new Vector3(1, 1, 1);
    }

}
