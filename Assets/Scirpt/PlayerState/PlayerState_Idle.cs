using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Date/stateMachine/PlayerState/Idle", fileName = "PlayerState_Idle")]
public class PlayerState_Idle : PlayStateManger
{
    [SerializeField] float acceleration = 1f;

    // Start is called before the first frame update
    public override void Enter()
    {
        //  animator.Play("Idle");
        base.Enter();
        CurrentVelocity = player.MoveSpeed;//进入空闲状态时候

        //  player.SetVelocityX(0f);//当玩家进入空闲状态的时候让刚体速度为0
    }

    public override void LogicUpdate()
    {

        if (input.Move)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Run));


        }
        if (player.CanHurt)
        {
            Debug.Log("受伤");
            playerStateMachine.SwitchState(typeof(playerState_Hurt));

        }
        if (input.AxisY < 0 && player.IsGrounded)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Duck));
        }
        if (input.ladder && player.CanLadder && player.canLadder())
        {
            playerStateMachine.SwitchState(typeof(playerState_ladder));
        }
        if (input.Jump)
        {
            playerStateMachine.SwitchState(typeof(playerState_JumpUp));
        }
        if (!player.IsGrounded)
        {
            playerStateMachine.SwitchState(typeof(playerState_Fall));
        }

        if (input.Attack && !input.Move)
        {
            playerStateMachine.SwitchState(typeof(playerState_attack));

        }
        CurrentVelocity = Mathf.MoveTowards(CurrentVelocity, 0, acceleration * Time.deltaTime);
    }
    public override void PhysicUpdate()
    {
        player.SetVelocityX(CurrentVelocity * input.AxisX);
    }
}
