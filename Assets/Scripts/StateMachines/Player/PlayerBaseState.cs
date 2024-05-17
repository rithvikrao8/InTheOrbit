using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine GenericStateMachine;

    public PlayerBaseState(PlayerStateMachine GenericStateMachine)
    {
        this.GenericStateMachine = GenericStateMachine;
    }

     protected void Move(float deltaTime)
    {
        Move(Vector3.zero, deltaTime);
    }

    protected void Move(Vector3 motion, float deltaTime)
    {
        GenericStateMachine.Controller.Move((motion + GenericStateMachine.ForceReceiver.Movement) * deltaTime);
    }

    protected void FaceTarget()
    {
        if(GenericStateMachine.Targeter.CurrentTarget == null) {return; }

        Vector3 lookPos = GenericStateMachine.Targeter.CurrentTarget.transform.position - GenericStateMachine.transform.position;
        lookPos.y = 0f;


        GenericStateMachine.transform.rotation = Quaternion.LookRotation(lookPos);
    }
    protected void returnToNormal() 
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

} 

