using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{
    Button button;

    public void Awake()
    {
        button = GetComponent<Button>();
    }

    public void Disable()
    {
        button.interactable = false;
    }

    public void Enable()
    {
        button.interactable = true;
    }

    public void OnPress()
    {
        //when the attack button is pressed:
        //tell the hero to do an attack as soon as the atb is charged. 

        //todo: the heroes list is now strictly heros instead of generic character, so don't need to cast as hero, i think.
        if(BattleManager.Instance.HeroesInBattle[0] is Hero h)
        {
            var enemiesRef = BattleManager.Instance.EnemiesInBattle;
            ActionHandler action = new ActionHandler(h, enemiesRef[Random.Range(0, enemiesRef.Count)]);
            action.AnimationSpeed = 4f;
            action.MoveStopOffset = -1.5f;
            h.SetQueuedAction(action);
        }
    }
}
