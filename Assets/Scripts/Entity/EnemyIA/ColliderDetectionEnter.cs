using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetectionEnter : MonoBehaviour {

    public GameObject toBroacast;
    public string messageEnter;
    public string messageExit;

    public void OnTriggerEnter(Collider other)
    {
        toBroacast.BroadcastMessage(messageEnter, other);
    }

    void OnTriggerExit(Collider other)
    {
        toBroacast.BroadcastMessage(messageExit, other);
    }

}
