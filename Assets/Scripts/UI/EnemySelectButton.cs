using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelectButton : MonoBehaviour
{
    public GameObject EnemyGO;

    public void SelectEnemy()
    {
        BattleManager.Instance.GetComponent<BattleStateMachine>();
    }
}
