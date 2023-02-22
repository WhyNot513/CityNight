using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Date/stateMachine/PlayerState/Fall", fileName = "playerState_Fall")]

public class playerState_Fall : PlayStateManger
{
    [SerializeField] AnimationCurve speedCurve;//动画曲线
    [SerializeField] float moveSpeed = 5f;
    public override void Enter()
    {

        base.Enter();
    }
    public override void LogicUpdate()
    {
        if (player.CanHurt)
        {

            playerStateMachine.SwitchState(typeof(playerState_Hurt));

        }
        if (player.IsGrounded)
        {
            {
                playerStateMachine.SwitchState(typeof(playerState_Land));
            }
        }
        if (input.Jump) //二段跳
        {

            //
            if (player.CanAirJump == true)
            {
                playerStateMachine.SwitchState(typeof(playerState_AirJump));

                player.CanAirJump = false;
                return;

            }
            input.SetJumpInputBufferTimer();

        }
    }

    public override void PhysicUpdate()
    {
        player.MoveX(moveSpeed);

        player.SetVelocityY(speedCurve.Evaluate(stateDuration)); //通过动画曲线获得掉落下来的时间
    }
}
