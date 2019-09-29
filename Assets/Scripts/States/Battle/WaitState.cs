using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//battle state that waits for an action to be sent to the battle manager, and then transitions the battle manager to the take action state
public class WaitState : IBattleState
{
    public void Enter()
    {
        //none
    }

    public void Execute()
    {
        if (BattleManager.Instance.HasActionToPerform())
        {
            Exit();
        }
    }

    public void Exit()
    {
        BattleManager.Instance.NewStateCallback(new TakeActionState());
    }
}
