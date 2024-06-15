using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingState : PlayerBaseState
{
    private float previousFrameTime;
    private bool alreadyAppliedForce;
    private Attack attack;
    private PlayerWeaponDamage activeWeapon;
    private int attackIndex;

    public PlayerAttackingState(PlayerStateMachine stateMachine, int attackIndex) : base(stateMachine)
    {
        this.attackIndex = attackIndex;
        attack = stateMachine.Attacks[attackIndex];
        activeWeapon = DetermineActiveWeapon(stateMachine);
    }

    public override void Enter()
    {
        if (activeWeapon == null)
        {
            Debug.LogError("Active weapon is not assigned in the PlayerStateMachine.");
            return;
        }

        activeWeapon.SetAttack(attack.Damage);
        GenericStateMachine.Animator.CrossFadeInFixedTime(attack.AnimationName, attack.TransitionDuration);
    }

    public override void Tick(float deltaTime)
    {
        Move(deltaTime);
        FaceTarget();

        float normalizedTime = GetNormalizedTime(GenericStateMachine.Animator);
        if (normalizedTime >= previousFrameTime && normalizedTime < 1f)
        {
            if (normalizedTime >= attack.ForceTime)
            {
                TryApplyForce();
            }

            if (GenericStateMachine.InputReader.IsAttacking)
            {
                TryComboAttack(normalizedTime);
            }
        }
        else
        {
            if (GenericStateMachine.Targeter.CurrentTarget != null)
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
        if (attack.ComboStateIndex == -1) { return; }
        if (normalizedTime < attack.ComboAttackTime) { return; }
        GenericStateMachine.SwitchState(new PlayerAttackingState(GenericStateMachine, attack.ComboStateIndex));
    }

    private void TryApplyForce()
    {
        if (alreadyAppliedForce) { return; }

        GenericStateMachine.ForceReceiver.AddForce(GenericStateMachine.transform.forward * attack.Force);
        alreadyAppliedForce = true;
    }

    public override void Exit() { }

    private float GetNormalizedTime(Animator animator)
    {
        AnimatorStateInfo currentInfo = animator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo nextInfo = animator.GetNextAnimatorStateInfo(0);
        if (animator.IsInTransition(0) && nextInfo.IsTag("Attack"))
        {
            return nextInfo.normalizedTime;
        }
        else if (!animator.IsInTransition(0) && currentInfo.IsTag("Attack"))
        {
            return currentInfo.normalizedTime;
        }
        else
        {
            return 0f;
        }
    }

    private PlayerWeaponDamage DetermineActiveWeapon(PlayerStateMachine stateMachine)
    {
        // Logic to determine the active weapon based on the attack index
        switch (attackIndex)
        {
            case 0:
            case 1:
                return stateMachine.Weapon1; // Use Weapon1 for the first two attacks
            case 2:
                return stateMachine.Weapon2; // Use Weapon2 for the third attack
            default:
                return stateMachine.Weapon1; // Default to Weapon1
        }
    }
}