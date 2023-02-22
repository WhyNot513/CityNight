using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Date/stateMachine/PlayerState/ladder", fileName = "playerState_ladder")]

public class playerState_ladder : PlayStateManger
{
    [SerializeField] float acceleration = 1f;
    [SerializeField] float runSpeed = 1f;
    [SerializeField, Header("横向移动速度")] float moveSpeed = 1f;
    public override void Enter()
    {
        player.SetVelocityX(0);
        base.Enter();
        player.SetUseGravity(0);
    }

    public override void Exit()
    {
        animator.speed = 1;
        player.SetUseGravity(1);
    }
    public override void LogicUpdate()
    {
        if ((player.IsGrounded && input.AxisY < 0) || !player.CanLadder)
        {
            Debug.Log($"player.IsGrounded: {player.IsGrounded}   !player.CanLadder{!player.CanLadder} ");
            Debug.LogWarning("走了");
            playerStateMachine.SwitchState(typeof(PlayerState_Idle));
            return;

        }
        if (!input.ladder)
        {
            animator.speed = 0;
            runSpeed = 0f;
        }
        else
        {
            runSpeed = 1f;
            animator.speed = 1;
            runSpeed = Mathf.MoveTowards(runSpeed, 0, acceleration * Time.deltaTime);
        }
        if (input.Move)
        {
            animator.speed = 1;
        }



    }

    public override void PhysicUpdate()
    {

        player.SetVelocityY(runSpeed * input.AxisY);
        player.MoveX(moveSpeed);



    }
}
