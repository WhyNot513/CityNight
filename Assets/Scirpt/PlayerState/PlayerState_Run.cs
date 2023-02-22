using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Date/stateMachine/PlayerState/Run", fileName = "PlayerState_Run")]

public class PlayerState_Run : PlayStateManger
{
    [SerializeField] float runspeed = 5f;
    [SerializeField] float acceleration = 1f;//玩家加速度
    // Start is called before the first frame update
    public override void Enter()
    {
        // animator.Play("Run");
        base.Enter();
        CurrentVelocity = player.MoveSpeed;//记录当前速度
    }

    public override void LogicUpdate()
    {
        if (input.Slider)
        {
            playerStateMachine.SwitchState(typeof(playerState_slider));
        }

        if (player.CanHurt)
        {
           
            playerStateMachine.SwitchState(typeof(playerState_Hurt));

        }
        if (input.ladder && player.CanLadder && player.canLadder())
        {

            playerStateMachine.SwitchState(typeof(playerState_ladder));
        }
        if (input.Attack)
        {
            playerStateMachine.SwitchState(typeof(playerState_runShoot));
        }
        if (!input.Move && !input.Slider && !player.CanHurt)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Idle));


        }
        if (input.Jump)
        {
            playerStateMachine.SwitchState(typeof(playerState_JumpUp));
        }
        if (!player.IsGrounded)
        {
            playerStateMachine.SwitchState(typeof(playerState_coyoteTime));
        }
        CurrentVelocity = Mathf.MoveTowards(CurrentVelocity, runspeed, acceleration * Time.deltaTime); //逐帧修改当前速度直到最大值
    }
    public override void PhysicUpdate()
    {
        player.MoveX(CurrentVelocity);
    }
}
