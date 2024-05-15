using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasingState : EnemyBaseState
{
    private readonly int MovementHash = Animator.StringToHash("Locomotion");
    private readonly int SpeedHash = Animator.StringToHash("Speed");

    private const float CrossFadeDuration = 0.1f;
    private const float AnimatorDampTime = 0.1f;

    public EnemyChasingState(EnemyStateMachine GenericStateMachine) : base(GenericStateMachine) { }

    public override void Enter()
    {
        GenericStateMachine.Animator.CrossFadeInFixedTime(MovementHash, CrossFadeDuration);

    }

    public override void Tick(float deltaTime)
    {

        if (!IsInChaseRange())
        {
            GenericStateMachine.SwitchState(new EnemyIdleState(GenericStateMachine));
            return;
        }
        else if (IsInAttackRange()) 
        {
            GenericStateMachine.SwitchState(new EnemyAttackingState(GenericStateMachine));
            return;
        }
        

        MoveToPlayer(deltaTime);
        FacePlayer();
        GenericStateMachine.Animator.SetFloat(SpeedHash, 1f, AnimatorDampTime, deltaTime);
    }

    public override void Exit() {
        GenericStateMachine.Agent.ResetPath();
        GenericStateMachine.Agent.velocity = Vector3.zero;
    }

    public void MoveToPlayer(float deltaTime) {
        GenericStateMachine.Agent.destination = GenericStateMachine.Player.transform.position;
        Move(GenericStateMachine.Agent.desiredVelocity.normalized * GenericStateMachine.MovementSpeed, deltaTime);

        GenericStateMachine.Agent.velocity = GenericStateMachine.Controller.velocity;
    }

    private bool IsInAttackRange() 
    {
        float playerDistanceSqr = (GenericStateMachine.Player.transform.position - GenericStateMachine.transform.position).sqrMagnitude;
        return playerDistanceSqr <= GenericStateMachine.AttackRange * GenericStateMachine.AttackRange;
    
    }
}
