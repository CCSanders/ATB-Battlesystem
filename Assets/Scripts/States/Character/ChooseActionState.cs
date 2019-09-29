using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ai class to choose what action to do. right now it justs attacks a random enemy. 
public class ChooseActionState : ICharacterState
{
    Character owner;
    public ChooseActionState(Character owner) { this.owner = owner; }
    ActionHandler myAction;

    public void Enter()
    {
        //get list of possible attacks for owner
        //get list of possible targets
        //do calculation to determine which target to attack
    }

    public void Execute()
    {
        //for now, create an attack action, pick a random target
        Character target;

        //if the owner of this action is of type enemy, choose a random hero. else 
        if (owner is Enemy e)
        {
            var heroesRef = BattleManager.Instance.HeroesInBattle;
            target = heroesRef[Random.Range(0, heroesRef.Count)];
            myAction = new ActionHandler(owner, target);
            myAction.AnimationSpeed = 4f;
            myAction.MoveStopOffset = 1.5f;
        }
        else
        {
            var enemiesRef = BattleManager.Instance.EnemiesInBattle;
            target = enemiesRef[Random.Range(0, enemiesRef.Count)];
            myAction = new ActionHandler(owner, target);
            myAction.AnimationSpeed = 4f;
            myAction.MoveStopOffset = -1.5f;
        }

        Exit();
    }

    //after an action is created, send it to the battle manager and go into the waiting state. 
    public void Exit()
    {
        BattleManager.Instance.AddAction(myAction);
        owner.NewStateCallback(new WaitingState());
    }
}
