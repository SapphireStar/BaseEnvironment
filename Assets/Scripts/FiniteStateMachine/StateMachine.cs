﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public string customName;
    private State mainStateType;
    public State CurrentState { get; private set; }

    private State nextState;


    private void Update()
    {
        if (nextState != null)
        {
            SetState(nextState);
            nextState = null;
        }
        if (CurrentState != null)
        {
            CurrentState.onUpdate();
        }
    }

    private void SetState(State _newState)
    {
        if (CurrentState != null)
        {
            CurrentState.onExit();
        }
        CurrentState = _newState;
        CurrentState.onEnter(this);
    }

    public void SetNextState(State _newState)
    {
        if (_newState != null)
            nextState = _newState;
    }

    private void FixedUpdate()
    {
        if (CurrentState != null)
            CurrentState.onFixedUpdate();
    }
    private void LateUpdate()
    {
        if (CurrentState != null)
            CurrentState.onLateUpdate();
    }
}
