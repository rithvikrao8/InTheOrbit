using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerBaseState
{
    public PlayerDeadState(PlayerStateMachine GenericStateMachine) : base(GenericStateMachine) { }

    public override void Enter()
    {
        GenericStateMachine.Ragdoll.ToggleRagdoll(true);
    }


    public override void Tick(float deltaTime)
    {

    }

    public override void Exit()
    {

    }
}
