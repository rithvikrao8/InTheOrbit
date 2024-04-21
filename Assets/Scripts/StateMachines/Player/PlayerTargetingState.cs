using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetingState : PlayerBaseState
{

    private readonly int TargetingBlendTreeHash = Animator.StringToHash("TargetingBlendTree");

    private readonly int TargetingForwardHash = Animator.StringToHash("TargetingForward");

    private readonly int TargetingRightHash = Animator.StringToHash("TargetingRight");


    public PlayerTargetingState(PlayerStateMachine GenericStateMachine) : base(GenericStateMachine) {}


    public override void Enter()
    {
        GenericStateMachine.InputReader.CancelEvent += OnCancel;

        GenericStateMachine.Animator.Play(TargetingBlendTreeHash);
    }

    public override void Tick(float deltaTime)
    {
        if(GenericStateMachine.Targeter.CurrentTarget == null)
        {
            GenericStateMachine.SwitchState(new PlayerFreeLookState(GenericStateMachine));
            return;
        }
        Vector3 movement = CalculateMovement();
        Move(movement * GenericStateMachine.TargetingMovementSpeed, deltaTime);

        UpdateAnimator(deltaTime);

        FaceTarget();




    }

    public override void Exit()
    {
        GenericStateMachine.InputReader.CancelEvent -= OnCancel;
    }

    private void OnCancel()
    {
        GenericStateMachine.Targeter.Cancel();


        GenericStateMachine.SwitchState(new PlayerFreeLookState(GenericStateMachine));
    }

    private Vector3 CalculateMovement()
    {
        Vector3 movement = new Vector3();

        movement += GenericStateMachine.transform.right * GenericStateMachine.InputReader.MovementValue.x;
        movement += GenericStateMachine.transform.forward * GenericStateMachine.InputReader.MovementValue.y;

        return movement;
    }

    private void UpdateAnimator(float deltaTime)
    {
        if (GenericStateMachine. InputReader.MovementValue.y == 0)
        {
            GenericStateMachine.Animator.SetFloat(TargetingForwardHash, 0, 0.1f, deltaTime);
        }
        else
        {
            float value = GenericStateMachine.InputReader.MovementValue.y > 0 ? 1f : -1f;
            GenericStateMachine.Animator.SetFloat(TargetingForwardHash, value, 0.1f, deltaTime);
        }
        if (GenericStateMachine. InputReader.MovementValue.x == 0)
        {
            GenericStateMachine.Animator.SetFloat(TargetingRightHash, 0, 0.1f, deltaTime);
        }
        else
        {
            float value = GenericStateMachine.InputReader.MovementValue.y > 0 ? 1f : -1f;
            GenericStateMachine.Animator.SetFloat(TargetingRightHash, value, 0.1f, deltaTime);
        }
    }

}
