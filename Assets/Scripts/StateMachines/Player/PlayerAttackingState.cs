using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAttackingState : PlayerBaseState
{

    private float previousFrameTime;

    private bool alreadyAppliedForce;

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
            if(normalizedTime >= attack.ForceTime)
            {
                TryAppplyForce();
            }

            if(GenericStateMachine.InputReader.IsAttacking)
            {
                TryComboAttack(normalizedTime);
            }
        }
        else
        {
            if(GenericStateMachine.Targeter.CurrentTarget != null)
            {
                GenericStateMachine.SwitchState(new PlayerTargetingState(GenericStateMachine));
            }
            else
            {
                GenericStateMachine.SwitchState(new PlayerFreeLookState(GenericStateMachine));
            }
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

    private void TryAppplyForce()
    {
        if(alreadyAppliedForce){return;}

        GenericStateMachine.ForceReceiver.AddForce(GenericStateMachine.transform.forward * attack.Force);

        alreadyAppliedForce = true;
    }


    public override void Exit()
    {

    }
     private float GetNormalizedTime()
    {
        AnimatorStateInfo currentInfo = GenericStateMachine.Animator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo nextInfo = GenericStateMachine.Animator.GetNextAnimatorStateInfo(0);
        if (GenericStateMachine.Animator.IsInTransition(0) && nextInfo.IsTag("Attack"))
        {
            return nextInfo.normalizedTime;
        }
        else if (!GenericStateMachine.Animator.IsInTransition(0) && currentInfo.IsTag("Attack"))
        {
            return currentInfo.normalizedTime;
        }
        else
        {
            return 0f;
        }
    }
}