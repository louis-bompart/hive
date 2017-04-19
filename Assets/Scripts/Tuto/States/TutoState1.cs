using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutoState1 : State
{


    public TutoState1(StateManager fms) : base(fms)
    {
    }

    public override void StateEnter()
    {
        base.StateEnter();
        DialogueManager.instance.lauchDialogue(DialogueDatabase.Instance().getDialogue("DialogueTuto1"));
        DialogueManager.instance.lauchDialogue(DialogueDatabase.Instance().getDialogue("DialogueTuto2"));
        DialogueManager.instance.lauchDialogue(DialogueDatabase.Instance().getDialogue("DialogueTuto3"));
        DialogueManager.instance.lauchDialogue(DialogueDatabase.Instance().getDialogue("DialogueTuto4"));
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
        if (SceneManager.GetActiveScene().name == "Release")
        {
            FSM.changeState(new TutoState2(FSM));
        }

    }

    public override void StateExit()
    {
        base.StateExit();

    }
}
