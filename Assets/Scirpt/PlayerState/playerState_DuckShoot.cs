using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Date/stateMachine/PlayerState/DuckShoot", fileName = "playerState_DuckShoot")]

public class playerState_DuckShoot : PlayStateManger
{
    [SerializeField] VoidEventChanels VoidEventChanels_BranchBullets;
    [SerializeField] VoidEventChanels VoidEventChanels_StopBranches;
    public override void Enter()
    {
        base.Enter();
        //  AduioManager.instance.PlayerSFX(player.AttackaudioData);
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
        if (input.StopAttack && IsAnimationFinshed)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Duck));
        }
        if (input.StopAttack && input.Move)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Run));
        }
        if (input.Move)
        {
            playerStateMachine.SwitchState(typeof(playerState_runShoot));
        }
        if (player.CanHurt)
        {

            playerStateMachine.SwitchState(typeof(playerState_Hurt));

        }
    }
}
