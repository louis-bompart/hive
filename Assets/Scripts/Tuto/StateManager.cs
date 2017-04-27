using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {

    State currentState;



	// Use this for initialization
	void Start () {
        changeState(new TutoState1(this));
    }
	
    void Awake()
    {
        
    }

	// Update is called once per frame
	void Update () {
        if(currentState != null)
        {
            currentState.StateUpdate();
        }
	}

    public void changeState(State newState)
    {   
        if(currentState != null)
        {
            currentState.StateExit();
        }
        
        currentState = newState;

        if(currentState != null)
        {
            currentState.StateEnter();
        }
      
    }
}
