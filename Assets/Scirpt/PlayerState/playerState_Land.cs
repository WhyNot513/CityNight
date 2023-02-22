using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Date/stateMachine/PlayerState/Land", fileName = "playerState_Land")]


public class playerState_Land : PlayStateManger
{
    [SerializeField] float stiffTime = 0.2f;//硬直时间
    public override void Enter()
    {

        player.CanAirJump = false;
        base.Enter();
        player.SetVelocity(Vector3.zero);//设置玩家速度为0
                                         //   player.CanAirJump = true;
    }
    public override void LogicUpdate()
    {
        if (input.Jump || input.HasJumpInputBuffer)
        {
            playerStateMachine.SwitchState(typeof(playerState_JumpUp));
        }
        if (stateDuration < stiffTime)
        {
            return;
        }
        if (input.Move)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Run));
        }
        if (IsAnimationFinshed)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Idle));
        }
        if (player.CanHurt)
        {

            playerStateMachine.SwitchState(typeof(playerState_Hurt));

        }
    }
    public override void Exit()
    {

        base.Exit();
    }
}
