using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingState : PlayerBaseState
{
    private Attack attack;

    public PlayerAttackingState(PlayerStateMachine GenericStateMachine, int attackId) : base(GenericStateMachine)
    {
        attack = GenericStateMachine.Attacks[attackId];
    }

    public override void Enter()
    {
        GenericStateMachine.Animator.CrossFadeInFixedTime(attack.AnimationName, 0.1f);
    }

    public override void Tick(float deltaTime)
    {
    }

    public override void Exit()
    {

    }
}
