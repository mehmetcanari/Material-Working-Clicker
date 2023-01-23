using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RegisterInput : MonoBehaviour
{
    public UnityEvent StateInvoker;

    private void Update()
    {
        switch (StateManager.Instance._states)
        {
            case GameStates.Idle:
                InitiliazeInput();
                break;
        }
    }

    private void InitiliazeInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StateInvoker?.Invoke();
        }
    }
}
