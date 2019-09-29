using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//battle state will pop an action from the battle manager, and tell the corresponding state machines to change state. 
public class TakeActionState : IBattleState
{
    public void Enter() {}

    public void Execute()
    {
        ActionHandler action = BattleManager.Instance.GetNextAction();
        action.ActionOwner.NewStateCallback(new ActionState(action));
        Exit();
    }

    public void Exit()
    {
        //todo? instead of putting the battle right into 'wait state' after the action is fired to start, 
        //possibily transition into 'action happening' state, wait for the action to announce that it's done
        //and then transition into 'waiting' to start firing more actions. 

        BattleManager.Instance.NewStateCallback(new WaitState());
    }
}
