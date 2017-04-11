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
       
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
        //To let the scene the time to proprely load
        deltaTime += Time.deltaTime;
        if(deltaTime > 1)
        {
            FSM.changeState(new TutoState3(FSM));
        }

    }

    public override void StateExit()
    {
        base.StateExit();
        DialogueManager.instance.lauchDialogue(DialogueDatabase.Instance().getDialogue("DialogueTuto5").Text);
        DialogueManager.instance.lauchDialogue(DialogueDatabase.Instance().getDialogue("DialogueTuto6").Text);
        DialogueManager.instance.lauchDialogue(DialogueDatabase.Instance().getDialogue("DialogueTuto7").Text);
        DialogueManager.instance.lauchDialogue(DialogueDatabase.Instance().getDialogue("DialogueTuto8").Text);
        DialogueManager.instance.lauchDialogue(DialogueDatabase.Instance().getDialogue("DialogueTuto9").Text);

    }
}
