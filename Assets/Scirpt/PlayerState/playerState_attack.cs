using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Date/stateMachine/PlayerState/attack", fileName = "playerState_attack")]

public class playerState_attack : PlayStateManger
{
    [SerializeField] float moveSpeed = 5f;

    [SerializeField] VoidEventChanels VoidEventChanels_BranchBullets;

    [SerializeField] VoidEventChanels VoidEventChanels_StopBranches;


    // Start is called before the first frame update
    public override void Enter()
    {
        // animator.Play("Run");
        base.Enter();
        //  AduioManager.instance.PlayerSFX(player.AttackaudioData);
    }
    public override void Exit()
    {
        VoidEventChanels_StopBranches.Broadcast();
        player.Isbranch = false;
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
            playerStateMachine.SwitchState(typeof(PlayerState_Idle));
        }
        if (input.Move)
        {
            playerStateMachine.SwitchState(typeof(playerState_runShoot));
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    public override void PhysicUpdate()
    {

        // player.Move(moveSpeed);
    }
}
