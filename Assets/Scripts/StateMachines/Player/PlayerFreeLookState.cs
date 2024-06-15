using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFreeLookState : PlayerBaseState
{
    private readonly int FreeLookBlendTreeHash = Animator.StringToHash("FreeLookBlendTree");
    private readonly int FreeLookSpeedHash = Animator.StringToHash("FreeLookSpeed");
    private const float AnimatorDampTime = 0.1f;
    private int attackCounter = 0;

    public PlayerFreeLookState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        GenericStateMachine.InputReader.TargetEvent += OnTarget;
        GenericStateMachine.Animator.CrossFadeInFixedTime(FreeLookBlendTreeHash, 0.1f);
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
        Move(movement * GenericStateMachine.FreeLookMovementSpeed, deltaTime);

        if (GenericStateMachine.InputReader.MovementValue == Vector2.zero)
        {
            GenericStateMachine.Animator.SetFloat(FreeLookSpeedHash, 0, AnimatorDampTime, deltaTime);
            return;
        }

        GenericStateMachine.Animator.SetFloat(FreeLookSpeedHash, 1, AnimatorDampTime, deltaTime);
        FaceMovementDirection(movement, deltaTime);
    }

    public override void Exit()
    {
        GenericStateMachine.InputReader.TargetEvent -= OnTarget;
    }

    private void OnTarget()
    {
        if (!GenericStateMachine.Targeter.SelectTarget()) { return; }
        GenericStateMachine.SwitchState(new PlayerTargetingState(GenericStateMachine));
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

    private void FaceMovementDirection(Vector3 movement, float deltaTime)
    {
        GenericStateMachine.transform.rotation = Quaternion.Lerp(
            GenericStateMachine.transform.rotation,
            Quaternion.LookRotation(movement),
            deltaTime * GenericStateMachine.RotationDamping);
    }
}

