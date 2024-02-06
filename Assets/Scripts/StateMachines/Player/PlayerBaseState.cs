using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine GenericStateMachine;

    public PlayerBaseState(PlayerStateMachine GenericStateMachine)
    {
        this.GenericStateMachine = GenericStateMachine;
    }
}

