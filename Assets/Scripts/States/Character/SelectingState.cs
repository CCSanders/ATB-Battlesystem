using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//state for when atb is full but the player has not chosen an action yet. similar to the waiting state. 
public class SelectingState : ICharacterState
{
    Hero owner;

    public SelectingState(Hero owner)
    {
        this.owner = owner;
    }

    public void Enter() { }

    public void Execute()
    {

    }

    public void Exit() {}
}