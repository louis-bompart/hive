using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoState1 : State
{
    private float deltaTime = 0;

    public TutoState1(StateManager fms) : base(fms)
    {
    }

    public override void StateEnter()
    {
        base.StateEnter();
        DialogueManager.instance.lauchDialogue(DialogueDatabase.Instance().getDialogue("EnterState1"));
        
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
        deltaTime += Time.deltaTime;
        //Debug.Log(DialogueDatabase.Instance());
        if(deltaTime >= 5)
        {
            FSM.changeState(new TutoState2(FSM));
        }

    }

    public override void StateExit()
    {
        base.StateExit();
        DialogueManager.instance.lauchDialogue(DialogueDatabase.Instance().getDialogue("ExitState1"));
    }
}
