using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerAction playerInputAction;
    Vector2 axes => playerInputAction.GamePlay.Axes.ReadValue<Vector2>();


    public float AxisX => axes.x;//X轴方向上的值
    public float AxisY => axes.y;

    // public bool Move => AxisX != 0f;//判断玩家什么时候移动
    public bool Move => AxisX != 0;//判断玩家什么时候移动

    public bool Jump => playerInputAction.GamePlay.Jump.WasPerformedThisFrame();
    //public bool StopJump => Input.GetKeyUp(KeyCode.W);
    public bool StopJump => playerInputAction.GamePlay.Jump.WasReleasedThisFrame();
    public bool HasJumpInputBuffer { get; set; }//判断是否存在跳跃输入缓冲
    [SerializeField] float JumpInputBufferTime = 0.5f;//跳跃输入缓冲持续时间
    WaitForSeconds waitJumpInputBufferTime;

    public bool Attack => playerInputAction.GamePlay.Shoot.WasPerformedThisFrame();
    public bool StopAttack => !playerInputAction.GamePlay.Shoot.IsPressed();

    public bool Slider => playerInputAction.GamePlay.Slider.WasPerformedThisFrame();
    public bool StopSlider => playerInputAction.GamePlay.Slider.WasReleasedThisFrame();

    public bool ladder => AxisY != 0;

    public bool addblen => playerInputAction.GamePlay.Addblone.WasPerformedThisFrame();

    public bool SwithBullet => playerInputAction.GamePlay.SwitchBullet.WasPerformedThisFrame();
    private void Awake()
    {
        playerInputAction = new PlayerAction();
        waitJumpInputBufferTime = new WaitForSeconds(JumpInputBufferTime);
        EnableGamePlayerInputs();
    }



    public void EnableGamePlayerInputs() //开启动作表

    {
        playerInputAction.GamePlay.Enable();
    }

    public void DisableGamePlayerInputs() //关闭动作表

    {
        playerInputAction.GamePlay.Disable();
    }



    private void OnEnable()
    {

        playerInputAction.GamePlay.Jump.canceled += delegate
        {
            HasJumpInputBuffer = false;
        };

    }


    private void OnGUI()
    {
        //Rect rect = new Rect(200, 200, 200, 200);
        //string message = "kkkk:" + HasJumpInputBuffer;
        //GUIStyle style = new GUIStyle();
        //style.fontSize = 20;
        //style.fontStyle = FontStyle.Bold;
        //GUI.Label(rect, message, style);
    }
    // Update is called once per frame

    /// <summary>
    /// 判断玩家左右移动方向
    /// </summary>
    void JudeMoveDire()
    {

    }
    public void SetJumpInputBufferTimer()
    {
        StopCoroutine(nameof(JumpInputBufferCoroutine));
        StartCoroutine(nameof(JumpInputBufferCoroutine));
    }
    IEnumerator JumpInputBufferCoroutine()
    {
        HasJumpInputBuffer = true;
        yield return waitJumpInputBufferTime;
        HasJumpInputBuffer = false;
    }

}
