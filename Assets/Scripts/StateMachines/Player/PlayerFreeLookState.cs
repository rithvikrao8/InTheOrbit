using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFreeLookState : PlayerBaseState
{
    private readonly int FreeLookSpeedHash = Animator.StringToHash("FreeLookSpeed");

    private const float AnimatorDampTime = 0.1f;


    public PlayerFreeLookState(PlayerStateMachine GenericStateMachine) : base(GenericStateMachine) { }

    public override void Enter()
    {

    }

    public override void Tick(float deltaTime)
    {
        Vector3 movement = CalculateMovement();



        GenericStateMachine.Controller.Move(movement * GenericStateMachine.FreeLookMovementSpeed * deltaTime);

        if (GenericStateMachine.InputReader.MovementValue == Vector2.zero) 
        {
            GenericStateMachine.Animator.SetFloat(FreeLookSpeedHash, 0, AnimatorDampTime,deltaTime);

            return; 
        }
        GenericStateMachine.Animator.SetFloat(FreeLookSpeedHash, 1, AnimatorDampTime,deltaTime);
        FaceMovementDirection(movement, deltaTime);
    }




    public override void Exit()
    {

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
