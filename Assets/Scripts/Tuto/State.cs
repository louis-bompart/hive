using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{

    protected StateManager FSM; 

    public State(StateManager fms)
    {
        FSM = fms;
    }

    //Call when state is activated
    virtual public void StateEnter()
    {

    }

    //Update of the state, used most of the time to check if the state should end
    virtual public void StateUpdate()
    {

    }

    //Call when we exit the state 
    virtual public void StateExit()
    {

    }
}
