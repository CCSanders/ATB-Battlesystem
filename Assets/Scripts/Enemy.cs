using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Character
{
    private void Start()
    {
        //on battle start, create a new charging state
        stateMachine.ChangeState(new ATBChargingState(this));
    }

    public override void ATBFinishedStateCallback()
    {
        NewStateCallback(new ChooseActionState(this));
    }
}
