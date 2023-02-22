using UnityEngine;

[CreateAssetMenu(menuName = "Date/stateMachine/PlayerState/Slider", fileName = "playerState_slider")]
public class playerState_slider : PlayStateManger
{
    [SerializeField] float acceleration = 1f;
    float Dir;
    public override void Enter()
    {
        base.Enter();
        player.cirecolid.offset = new Vector2(player.cirecolid.offset.x, player.cirecolid.offset.y - 0.05f);
        player.cirecolid.size = new Vector2(player.cirecolid.size.x, player.cirecolid.size.y - 0.1f);
        CurrentVelocity = player.MoveSpeed;
        Dir = input.AxisX;
    }

    public override void LogicUpdate()
    {

        // Debug.Log(CurrentVelocity);
        if (player.MoveSpeed <= 0.01f || input.StopSlider)
        {

            playerStateMachine.SwitchState(typeof(PlayerState_Idle));
        }

        CurrentVelocity = Mathf.MoveTowards(CurrentVelocity, 0, acceleration * Time.deltaTime);
    }
    public override void PhysicUpdate()
    {

        player.SetVelocityX(CurrentVelocity * Dir);
    }
    public override void Exit()
    {
        player.cirecolid.offset = new Vector2(player.cirecolid.offset.x, player.cirecolid.offset.y + 0.05f);
        player.cirecolid.size = new Vector2(player.cirecolid.size.x, player.cirecolid.size.y + 0.1f);
        base.Exit();
    }
}
