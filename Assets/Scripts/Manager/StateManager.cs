using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static StateManager Instance;
    public GameStates _states;
    private int _stateIndex;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeState(int _index)
    {
        switch (_index)
        {
            case 0:
                _states = GameStates.Idle;
                break;
            
            case 1:
                _states = GameStates.Play;
                break;
        }
    }
}

public enum GameStates
{
    Idle,
    Play
}
