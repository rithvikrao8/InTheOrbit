using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackingState : EnemyBaseState
{
    private readonly int AttackHash = Animator.StringToHash("Attack");
    private const float TransitionDuration = 0.1f;
   
    public EnemyAttackingState(EnemyStateMachine GenericStateMachine) : base(GenericStateMachine)
    {
    }

    public override void Enter()
    {
        GenericStateMachine.Animator.CrossFadeInFixedTime(AttackHash, TransitionDuration);
        GenericStateMachine.Weapon.SetAttack(GenericStateMachine.AttackDamage);
    }


    public override void Tick(float deltaTime)
    {
    }

    public override void Exit()
    {
    }



}
