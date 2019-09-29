using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private static BattleManager instance = null;

    public static BattleManager Instance
    {
        get
        {
            //if the instance reference is null, try to find it
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(BattleManager)) as BattleManager;
            }

            //if its still not found, create it 
            if(instance == null)
            {
                var go = new GameObject("Battle Manager");
                instance = go.AddComponent<BattleManager>();
            }

            return instance;
        }
    }

    //ensures that the instance is destroyed when the game is stopped in the editor
    private void OnApplicationQuit()
    {
        instance = null;
    }

    private BattleStateMachine stateMachine;

    public List<ActionHandler> PerformList = new List<ActionHandler>(); //ai actions
    public List<Hero> HeroesInBattle = new List<Hero>();
    public List<Enemy> EnemiesInBattle = new List<Enemy>();

    private void Awake()
    {
        stateMachine = GetComponent<BattleStateMachine>();
    }

    void Start()
    {
        HeroesInBattle.AddRange(FindObjectsOfType<Hero>());
        for(int i = 1; i < HeroesInBattle.Count; i++)
        {
            HeroesInBattle[i].aiHero = true;
        }
        EnemiesInBattle.AddRange(FindObjectsOfType<Enemy>());
        stateMachine.ChangeState(new WaitState());
    }

    public void AddAction(ActionHandler input)
    {
        PerformList.Add(input);
    }

    public bool HasActionToPerform()
    {
        return PerformList != null && PerformList.Count > 0 ? true : false;
    }

    public ActionHandler GetNextAction()
    {
        ActionHandler nextAction = PerformList[0];
        PerformList.RemoveAt(0); //runs in O(n) time. not great, but the action list should never be more than n = 10.
        return nextAction;
    }

    public void NewStateCallback(IBattleState state)
    {
        stateMachine.ChangeState(state);
    }
}