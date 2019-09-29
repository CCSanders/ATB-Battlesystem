using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATBChargingState : ICharacterState
{
    Character owner;
    float currentATBCharge;
    float maxATBCharge;

    public ATBChargingState(Character owner) { this.owner = owner; }

    public void Enter()
    {
        currentATBCharge = owner.currentATBCharge;
        maxATBCharge = owner.maxATBCharge;
    }

    public void Execute()
    {
        currentATBCharge += Time.deltaTime;
        owner.SetCurrentATB(currentATBCharge);

        if(currentATBCharge >= maxATBCharge)
        {
            Exit();
        }
    }

    public void Exit()
    {
        owner.ATBFinishedStateCallback();
    }
}