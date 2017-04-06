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
        DialogueManager.instance.lauchDialogue(DialogueDatabase.Instance().getDialogue("TestDialogue").Text);
        //DialogueManager.instance.lauchDialogue(DialogueDatabase.Instance().getDialogue("TestDialogue").Text);
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
        deltaTime += Time.deltaTime;
        //Debug.Log(DialogueDatabase.Instance());
        if(deltaTime >= 5)
        {
            FSM.changeState(null);
        }

    }

    public override void StateExit()
    {
        base.StateExit();
        DialogueManager.instance.lauchDialogue(DialogueDatabase.Instance().getDialogue("TestDialogue2").Text);
        //DialogueManager.instance.lauchDialogue("Hello je suis une licorne et j'ai la banane! (Exit State1)");
    }
}
