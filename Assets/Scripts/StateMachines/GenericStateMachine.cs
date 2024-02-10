using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericStateMachine : MonoBehaviour
{

    private State currentState;

    public void SwitchState(State newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }
    public InputReader InputReader { get; private set; }

    private void Awake()
    {
        InputReader = GetComponent<InputReader>();
    }
    private void Update()
    {
        currentState?.Tick(Time.deltaTime);
    }
}

