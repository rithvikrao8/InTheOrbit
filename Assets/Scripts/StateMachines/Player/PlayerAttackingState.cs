using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingState : PlayerBaseState
{

    private float previousFrameTime;

    private Attack attack;


    public PlayerAttackingState(PlayerStateMachine GenericStateMachine, int attackIndex) : base(GenericStateMachine)
    {
        attack = GenericStateMachine.Attacks[attackIndex];
    }

    public override void Enter()
    {
        GenericStateMachine.Animator.CrossFadeInFixedTime(attack.AnimationName, attack.TransitionDuration);
       
    }

    public override void Tick(float deltaTime)
    {
        Move(deltaTime);

        FaceTarget();

        float normalizedTime =  GetNormalizedTime(GenericStateMachine.Animator);
        if(normalizedTime > previousFrameTime && normalizedTime < 1f)
        {
            if(GenericStateMachine.InputReader.IsAttacking)
            {
                TryComboAttack(normalizedTime);
            }
        }
        else
        {
            //go back to locomotion
        }

        previousFrameTime = normalizedTime;
    }

    private void TryComboAttack(float normalizedTime)
    {
        if(attack.ComboStateIndex == -1) {return;}

        if(normalizedTime < attack.ComboAttackTime) {return;}

        GenericStateMachine.SwitchState
        (
            new PlayerAttackingState
            (
                GenericStateMachine,
                attack.ComboStateIndex
            )
        );
    }

    public override void Exit()
    {

    }
    

}
