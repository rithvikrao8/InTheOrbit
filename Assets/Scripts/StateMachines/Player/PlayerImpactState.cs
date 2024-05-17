using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImpactState : PlayerBaseState
{
    private readonly int impactHash = Animator.StringToHash("impact");
    private const float CrossFadeDuration = 0.1f;
    private float duration = 1f;
    public PlayerImpactState(PlayerStateMachine GenericStateMachine) : base(GenericStateMachine){ }


    public override void Enter()
    {
        GenericStateMachine.Animator.CrossFadeInFixedTime(impactHash, CrossFadeDuration);
    }
    public override void Tick(float deltaTime)
    {
        Move(deltaTime);

        duration -= deltaTime;

        if(duration <= 0f) 
        {
            returnToNormal();
        }
    }

    public override void Exit(){}



}
