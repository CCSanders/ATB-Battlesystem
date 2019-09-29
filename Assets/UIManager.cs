using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance = null;

    public static UIManager Instance
    {
        get
        {
            //if the instance reference is null, try to find it
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(UIManager)) as UIManager;
            }

            //if its still not found, create it 
            if (instance == null)
            {
                var go = new GameObject("UI Manager");
                instance = go.AddComponent<UIManager>();
            }

            return instance;
        }
    }

    //ensures that the instance is destroyed when the game is stopped in the editor
    private void OnApplicationQuit()
    {
        instance = null;
    }

    public AttackButton attackButton;
    
    void EnableActionButtons()
    {
        attackButton.Enable();
    }

    void DisableActionButtons()
    {
        attackButton.Disable();
    }
}
