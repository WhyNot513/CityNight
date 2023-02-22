using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Date/stateMachine/PlayerState/runShoot", fileName = "playerState_runShoot")]

public class playerState_runShoot : PlayStateManger
{
    [SerializeField, Header("最大速度")] float runspeed = 5f;
    [SerializeField, Header("加速度")] float acceleration = 1f;//玩家加速度
    [SerializeField] VoidEventChanels VoidEventChanels_BranchBullets;
    [SerializeField] VoidEventChanels VoidEventChanels_StopBranches;
    public override void Enter()
    {
        base.Enter();


        CurrentVelocity = player.MoveSpeed;
    }

    public override void Exit()
    {

        VoidEventChanels_StopBranches.Broadcast();
        player.Fire = false;
    }
    public override void LogicUpdate()
    {


        if (IsAnimationFinshed && player.Fire == false)
        {
            player.Isbranch = true;
            player.Fire = true;

        }
        if (player.Isbranch == true)
        {

            VoidEventChanels_BranchBullets.Broadcast();

            player.Isbranch = false;
        }
        if ((!input.Move && input.StopAttack))
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Idle));

        }


        if ((input.Move) && input.StopAttack && IsAnimationFinshed)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Run));

        }

        CurrentVelocity = Mathf.MoveTowards(CurrentVelocity, runspeed, acceleration * Time.deltaTime); //逐帧修改当前速度直到最大值
    }
    public override void PhysicUpdate()
    {
        player.MoveX(CurrentVelocity);
    }


}
