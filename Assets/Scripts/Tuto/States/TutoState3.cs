using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoState3 : State
{

    InventoryController shipInv;
    public TutoState3(StateManager fms) : base(fms)
    {
    }

    public override void StateEnter()
    {
        base.StateEnter();
        shipInv = GameObject.Find("Inventory").GetComponent<InventoryController>();
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
        if(shipInv.GetQuantity(100)>=10 && shipInv.GetQuantity(102) >= 10 && shipInv.GetQuantity(103)>= 5 )
        {
            FSM.changeState(new TutoState4(FSM));
        }
    }

    public override void StateExit()
    {
        base.StateExit();
        DialogueManager.instance.lauchDialogue(DialogueDatabase.Instance().getDialogue("DialogueTuto10").Text);
    }
}
