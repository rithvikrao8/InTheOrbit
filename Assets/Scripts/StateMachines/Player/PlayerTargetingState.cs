using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetingState : PlayerBaseState
{
    private readonly int TargetingBlendTreeHash = Animator.StringToHash("TargetingBlendTree");
    private readonly int TargetingSpeedHash = Animator.StringToHash("TargetingSpeed");
    private const float AnimatorDampTime = 0.1f;
    private int attackCounter = 0;

    public PlayerTargetingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        GenericStateMachine.InputReader.TargetEvent += OnTarget;
        GenericStateMachine.Animator.CrossFadeInFixedTime(TargetingBlendTreeHash, 0.1f);
    }

    public override void Tick(float deltaTime)
    {
        if (GenericStateMachine.InputReader.IsAttacking)
        {
            GenericStateMachine.SwitchState(new PlayerAttackingState(GenericStateMachine, attackCounter));
            attackCounter = (attackCounter + 1) % 3; // Increment and reset counter after 3 attacks
            return;
        }

        Vector3 movement = CalculateMovement();
        Move(movement * GenericStateMachine.TargetingMovementSpeed, deltaTime);

        if (GenericStateMachine.InputReader.MovementValue == Vector2.zero)
        {
            GenericStateMachine.Animator.SetFloat(TargetingSpeedHash, 0, AnimatorDampTime, deltaTime);
            return;
        }

        GenericStateMachine.Animator.SetFloat(TargetingSpeedHash, 1, AnimatorDampTime, deltaTime);
        FaceTargetDirection(movement, deltaTime);
    }

    public override void Exit()
    {
        GenericStateMachine.InputReader.TargetEvent -= OnTarget;
    }

    private void OnTarget()
    {
        if (!GenericStateMachine.Targeter.SelectTarget()) { return; }
        GenericStateMachine.SwitchState(new PlayerFreeLookState(GenericStateMachine));
    }

    private Vector3 CalculateMovement()
    {
        Vector3 forward = GenericStateMachine.MainCameraTransform.forward;
        Vector3 right = GenericStateMachine.MainCameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        return forward * GenericStateMachine.InputReader.MovementValue.y + right * GenericStateMachine.InputReader.MovementValue.x;
    }

    private void FaceTargetDirection(Vector3 movement, float deltaTime)
    {
        GenericStateMachine.transform.rotation = Quaternion.Lerp(
            GenericStateMachine.transform.rotation,
            Quaternion.LookRotation(movement),
            deltaTime * GenericStateMachine.RotationDamping);
    }
}

