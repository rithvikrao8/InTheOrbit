using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    private readonly int MovementHash = Animator.StringToHash("Movement"); // Replace 'movement' with the name of animation
    private readonly int SpeedHash = Animator.StringToHash("Speed");

    private const float CrossFadeDuration = 0.1f;
    private const float AnimatorDampTime = 0.1f;
    
    public EnemyIdleState(EnemyStateMachine GenericStateMachine) : base(GenericStateMachine) { }

    public override void Enter()
    {
        GenericStateMachine.Animator.CrossFadeInFixedTime(MovementHash, CrossFadeDuration);
        
    }

    public override void Tick(float deltaTime)
    {
        Move(deltaTime);

        if(IsInChaseRange())
        {
            GenericStateMachine.SwitchState(new EnemyChasingState(GenericStateMachine));
            return;
        }

        GenericStateMachine.Animator.SetFloat(SpeedHash, 0f, AnimatorDampTime, deltaTime);
    }

    public override void Exit() { }
}
