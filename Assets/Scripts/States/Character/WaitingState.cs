using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//for when the ai has chosen an action but the battle manager is processing other turns first. 
public class WaitingState : ICharacterState
{
    public void Enter() {}

    public void Execute() { }

    public void Exit() { }
}