using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoState2 : State
{

    private float deltaTime = 0;

    public TutoState2(StateManager fms) : base(fms)
    {
    }

    public override void StateEnter()
    {
        base.StateEnter();
        DialogueManager.instance.lauchDialogue(DialogueDatabase.Instance().getDialogue("EnterState2").Text);
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
        deltaTime += Time.deltaTime;
        if (deltaTime >= 5)
        {
            FSM.changeState(null);
        }
    }

    public override void StateExit()
    {
        base.StateExit();
        DialogueManager.instance.lauchDialogue(DialogueDatabase.Instance().getDialogue("ExitState2").Text);
    }
}
