using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Date/stateMachine/PlayerState/coyoteTime", fileName = "playerState_coyoteTime")]

public class playerState_coyoteTime : PlayStateManger
{

    // Start is called before the first frame update
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float coyoteTime = 0.1f;
    public override void Enter()
    {
        // animator.Play("Run");
        base.Enter();
        player.SetUseGravity(0);
    }

    public override void Exit()
    {
        player.SetUseGravity(1);
    }
    public override void LogicUpdate()
    {

        if (input.Jump)
        {
            playerStateMachine.SwitchState(typeof(playerState_JumpUp));
        }
        if (stateDuration > coyoteTime || !input.Move)
        {
            playerStateMachine.SwitchState(typeof(playerState_Fall));
        }

    }
    public override void PhysicUpdate()
    {
        player.MoveX(runSpeed);
    }
}
