using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Date/stateMachine/PlayerState/Duck", fileName = "PlayerState_Duck")]

public class PlayerState_Duck : PlayStateManger
{
    public override void Enter()
    {
        // animator.Play("Run");
        base.Enter();
        player.SetVelocityX(0);

    }
    public override void LogicUpdate()
    {
        if (player.CanHurt)
        {
            player.CanHurt = false;
            //  playerStateMachine.SwitchState(typeof(playerState_Hurt));

        }
        if (input.AxisY != -1)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Idle));
        }
        if (input.Attack)
        {
            playerStateMachine.SwitchState(typeof(playerState_DuckShoot));
        }

    }
}
