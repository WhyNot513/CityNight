using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Date/stateMachine/PlayerState/JumpUp", fileName = "playerState_JumpUp")]
public class playerState_JumpUp : PlayStateManger
{
    [SerializeField] float jumpForce = 7f;
    [SerializeField] float moveSpeed = 5f;
    public override void Enter()
    {

        base.Enter();
        input.HasJumpInputBuffer = false;
        player.SetVelocityY(jumpForce);
    }
    public override void LogicUpdate()
    {
        if (input.StopJump || player.IsFallling)
        {
            playerStateMachine.SwitchState(typeof(playerState_Fall));
        }
        if (input.ladder && player.CanLadder && player.canLadder())
        {
            playerStateMachine.SwitchState(typeof(playerState_ladder));
        }
    }
    public override void PhysicUpdate()
    {

        player.MoveX(moveSpeed);
    }

}
