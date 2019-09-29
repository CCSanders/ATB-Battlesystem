using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BattleStateMachine : MonoBehaviour
{
    public IBattleState currentState;

    public void Update()
    {
        if (currentState != null)
        {
            currentState.Execute();
        }
    }

    public void ChangeState(IBattleState newState)
    {
        Debug.Log("Battle state changed from '" + currentState + "' to '" + newState + "'");
        currentState = newState;
        currentState.Enter();
    }
}
