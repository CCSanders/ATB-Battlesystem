using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ActionHandler
{
    public Character ActionOwner;
    public Character ActionTarget;
    public float ActionCost = 1f; //atb cost? right now its just going to be 1.
    private Vector3 originalOwnerPos;

    public ActionHandler(Character owner, Character target, float cost = 1f)
    {
        ActionOwner = owner;
        ActionTarget = target;
        ActionCost = cost;
        originalOwnerPos = owner.transform.position;
    }

    //todo: this should hold information regarding the animation. possibliy an id from the action that will align with a scriptable object database for animations? idk 
    //current just going to store the "animation speed" as the movement speed of all actions that move. 

    //int actionId = ?;
    //ActionType actionType = ?;
    //int animationId = ?;

    public float AnimationSpeed = -1f;
    public float MoveStopOffset = 0f; //this is to stop moving actions from going inside of their target. assumed to be on the x axis, since we are dealing with cubes right now.

    //returns true if target is not null and not equal to the owner
    public bool HasTargetNotSelf()
    {
        return (ActionTarget && ActionTarget != ActionOwner);
    }

    //returns the position vector of the target with the offset, if it exists. if it doesn't just return the current position to the owner doesn't move
    public Vector3 GetTargetPosition()
    {
        if (!HasTargetNotSelf())
        {
            Debug.Log("tried to access a target pos, but action doesn't have non-self target.. returning owner position");
            return ActionOwner.transform.position;
        }

        return new Vector3(ActionTarget.transform.position.x + MoveStopOffset, ActionTarget.transform.position.y, ActionTarget.transform.position.z);
    }

    //should only be called AFTER calling get target position, since the owner position will most likely be changing during the action
    public Vector3 GetOriginalOwnerPosition()
    {
        return originalOwnerPos;
    }
}
