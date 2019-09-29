using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the state where a character is performming an action. actions can be casting a spell, defending, healing, attacking, etc. 
public class ActionState : ICharacterState
{
    //action handler contains info about move type, who the owner of the action is, who the target of the action is
    private ActionHandler myAction;

    public ActionState(ActionHandler myAction) { this.myAction = myAction; }

    public void Enter() {
        myAction.ActionOwner.DoAction(TimeForAction());
    }

    public void Execute() {}

    public void Exit()
    {
        myAction.ActionOwner.NewStateCallback(new ATBChargingState(myAction.ActionOwner));
    }

    //todo: store this action in a different method, and instead just get the action and pass it to the owner. 
    private IEnumerator TimeForAction()
    {
        //if the action has a target and the target is not the same as the owner, we want to do the animation stored in the action. right now, we are assuming that all actions will move the character towards the other)
        Vector3 targetPos = myAction.GetTargetPosition();
        while (MoveTowardsTarget(targetPos))
        {
            yield return null;
            targetPos = myAction.GetTargetPosition();
        }

        yield return new WaitForSeconds(1f);

        //do damage
        Debug.Log(myAction.ActionOwner + " just attacked " + myAction.ActionTarget + " for 0 damage!");
        myAction.ActionOwner.DecreaseATB();

        //animate back to start position
        Vector3 ownerPos = myAction.GetOriginalOwnerPosition();
        while (MoveTowardsTarget(ownerPos))
        {
            yield return null;
        }

        Exit();
    }

    private bool MoveTowardsTarget(Vector3 target)
    {
        return target != (myAction.ActionOwner.transform.position = Vector3.MoveTowards(myAction.ActionOwner.transform.position, target, myAction.AnimationSpeed * Time.deltaTime));
    }
}