using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState : State
{
    protected EnemyStateMachine GenericStateMachine;

    public EnemyBaseState(EnemyStateMachine GenericStateMachine)
    {
        this.GenericStateMachine = GenericStateMachine;
    }

    protected void Move(float deltaTime)
    {
        Move(Vector3.zero, deltaTime);
    }

    protected void Move(Vector3 motion, float deltaTime)
    {
        GenericStateMachine.Controller.Move((motion + GenericStateMachine.ForceReciever.Movement) * deltaTime);
    }

    protected bool IsInChaseRange()
    {
        float playerDistanceSqr = (GenericStateMachine.Player.transform.position - GenericStateMachine.transform.position).sqrMagnitude;
        
        return playerDistanceSqr <= GenericStateMachine.PlayerDetectionRange * GenericStateMachine.PlayerDetectionRange;
    }
}
