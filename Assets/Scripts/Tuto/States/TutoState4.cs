using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutoState4 : State
{

    private float deltaTime = 0;

    public TutoState4(StateManager fms) : base(fms)
    {
    }

    public override void StateEnter()
    {
        base.StateEnter();
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
        if(SceneManager.GetActiveScene().name == "Bridge" || SceneManager.GetActiveScene().name == "Factory" || SceneManager.GetActiveScene().name == "StorageBay")
        {
            deltaTime += Time.deltaTime;
            if(deltaTime > 0.5 )
            {
                GameObject.Find("Stats").GetComponent<BaseStats>().printerStat = 1;
                GameObject.Find("Stats").GetComponent<BaseStats>().scanRangeStat = 1;
                FSM.changeState(new TutoState5(FSM));
            }

        }
    }

    public override void StateExit()
    {
        base.StateExit();
        DialogueManager.instance.lauchDialogue(DialogueDatabase.Instance().getDialogue("DialogueTuto11"));
        DialogueManager.instance.lauchDialogue(DialogueDatabase.Instance().getDialogue("DialogueTuto12"));
    }
}
