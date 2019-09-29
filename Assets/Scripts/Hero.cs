using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : Character
{
    public Image ATBBar;
    public List<ActionHandler> QueuedActions = new List<ActionHandler>();
    public bool aiHero = false;

    private void Start()
    {
        //on battle start, create a new charging state
        stateMachine.ChangeState(new ATBChargingState(this));
    }

    //resource access
    public Image GetATBBar()
    {
        return this.ATBBar;
    }

    //reduces the current atb charge by the max * factor. i.e. if you want to reduce the charge to 0, you have a factor of 1. 
    public override void DecreaseATB(float factor = 1f)
    {
        base.DecreaseATB(factor);
        UpdateATBBar();
    }

    public override void SetCurrentATB(float newCharge)
    {
        base.SetCurrentATB(newCharge);
        UpdateATBBar();
    }

    public void UpdateATBBar()
    {
        float percentCharge = currentATBCharge / maxATBCharge;
        ATBBar.transform.localScale = new Vector3(Mathf.Clamp(percentCharge, 0f, 1f), ATBBar.transform.localScale.y, ATBBar.transform.localScale.z);
    }

    //when atb is done
    public override void ATBFinishedStateCallback()
    {
        if (aiHero)
        {
            stateMachine.ChangeState(new ChooseActionState(this));
            return;
        }

        if (QueuedActions.Count > 0)
        {
            stateMachine.ChangeState(new ActionState(GetNextAction()));
        }
        else
        {
            stateMachine.ChangeState(new SelectingState(this));
        }
    }

    public void SetQueuedAction(ActionHandler action)
    {
        QueuedActions.Add(action);
        if(stateMachine.currentState is SelectingState s){
            stateMachine.ChangeState(new ActionState(GetNextAction()));
        }
    }

    public ActionHandler GetNextAction()
    {
        ActionHandler nextAction = QueuedActions[0];
        QueuedActions.RemoveAt(0); //runs in O(n) time. not great, but the action list should never be more than n = 10.
        return nextAction;
    }
}
