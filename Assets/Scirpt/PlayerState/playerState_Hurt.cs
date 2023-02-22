using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Date/stateMachine/PlayerState/hurt", fileName = "playerState_Hurt")]

public class playerState_Hurt : PlayStateManger
{
    float addForce = 2f;
    [SerializeField] float acceleration = 1f;

    float dir => player.gameObject.GetComponent<Transform>().localScale.x;
    public override void Enter()
    {
        base.Enter();
        addForce = 2f;
        player.SetVelocityX(0);
        player.SetVelocityY(0);
        input.DisableGamePlayerInputs();


    }
    public override void Exit()
    {
        input.EnableGamePlayerInputs();
        player.CurrentHealth -= 10;
        player.statebar.UpdateStats(player.CurrentHealth, player.MaxHealth);
    }
    public override void LogicUpdate()
    {

        if (IsAnimationFinshed)
        {
            player.CanHurt = false;
            playerStateMachine.SwitchState(typeof(PlayerState_Idle));
        }
        addForce = Mathf.MoveTowards(addForce, 0, acceleration * Time.deltaTime); //逐帧修改当前速度直到最大值
    }


    public override void PhysicUpdate()
    {

        player.SetVelocityX(addForce * -dir);
        player.SetVelocityY(addForce);
    }



}
