using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyImpactState : EnemyBaseState
{
    private readonly int impactHash = Animator.StringToHash("impact");
    private const float CrossFadeDuration = 0.1f;
    private float duration = 0.2f;
    public EnemyImpactState(EnemyStateMachine GenericStateMachine) : base(GenericStateMachine) { }


    public override void Enter()
    {
        GenericStateMachine.Animator.CrossFadeInFixedTime(impactHash, CrossFadeDuration);
    }
    public override void Tick(float deltaTime)
    {
        Move(deltaTime);
        duration -= deltaTime;

        if (duration <= 0f)
        {
            GenericStateMachine.SwitchState(new EnemyIdleState(GenericStateMachine));
        }
    }

    public override void Exit() { }



}
