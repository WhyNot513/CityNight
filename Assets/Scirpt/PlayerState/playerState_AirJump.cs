using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Date/stateMachine/PlayerState/Airjump", fileName = "playerState_AirJump")]

public class playerState_AirJump : PlayStateManger
{
    // Start is called before the first frame update
    [SerializeField] float jumpForce = 7f;
    [SerializeField] float moveSpeed = 5f;
    public override void Enter()
    {

        base.Enter();
        player.SetVelocityY(jumpForce);
    }
    public override void LogicUpdate()
    {
      
        if (input.StopJump || player.IsFallling)
        {

            playerStateMachine.SwitchState(typeof(playerState_Fall));
        }
    }
    public override void PhysicUpdate()
    {

        player.MoveX(moveSpeed);
    }
}
