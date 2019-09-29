using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour
{
    public CharacterData characterData;

    public float currentATBCharge = 0f; //in seconds
    public float maxATBCharge = 5f; //in seconds

    protected CharacterStateMachine stateMachine;

    private void Awake()
    {
        stateMachine = GetComponent<CharacterStateMachine>();
    }

    //state changers
    public void NewStateCallback(ICharacterState newState)
    {
        stateMachine.ChangeState(newState);
    }

    //reduces the current atb charge by the max * factor. i.e. if you want to reduce the charge to 0, you have a factor of 1. 
    public virtual void DecreaseATB(float factor = 1f)
    {
        currentATBCharge = Mathf.Clamp(currentATBCharge - (factor * maxATBCharge), 0, maxATBCharge);
    }

    public virtual void SetCurrentATB(float newCharge)
    {
        currentATBCharge = newCharge;
    }

    public abstract void ATBFinishedStateCallback();

    //this is assuming there is a multiframe ienumerator action from the action state
    public void DoAction(IEnumerator action)
    {
        StartCoroutine(action);
    }
}
