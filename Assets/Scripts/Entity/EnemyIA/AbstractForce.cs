using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractForce : MonoBehaviour {

    public float weight = 15;

    public abstract Vector3 ComputeForce();
}
