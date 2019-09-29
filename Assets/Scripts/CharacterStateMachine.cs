using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterStateMachine : MonoBehaviour
{
    /*
     * Generic Character State Machine Flow
     * 
     * Hero: 
     * ATB Charging -> Selecting State? -> Action State -> ATB Charging -> (dead state)
     * 
     * Enemy:
     * ATB Charging -> Choose Action State -> Action State -> ATB Charging -> (dead state)
     */

    public ICharacterState currentState;

    public void Update()
    {
        if (currentState != null)
        {
            currentState.Execute();
        }
    }

    public void ChangeState(ICharacterState newState)
    {
        Debug.Log("Character state changed from '" + currentState + "' to '" + newState + "'");
        currentState = newState;
        currentState.Enter();
    }
}