using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetectionEnter : MonoBehaviour {

    public GameObject recipient;
    public string messageEnter;
    public string messageExit;

    public void OnTriggerEnter(Collider other)
    {
        recipient.SendMessage(messageEnter, other);
    }

    void OnTriggerExit(Collider other)
    {
        recipient.SendMessage(messageExit, other);
    }

}
