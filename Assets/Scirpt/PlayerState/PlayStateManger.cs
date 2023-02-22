using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayStateManger : ScriptableObject, IState
{

    [SerializeField] string stateName;//状态名称
    [SerializeField, Range(0f, 1f)] float transitionDuration = 0.1f;//动画融合百分比
    float stateStartTime;//状态开始的时间

    int stateHash;//状态名称对应的哈希值
    protected Animator animator;
    protected PlayerStateMachine playerStateMachine;
    protected PlayerInput input;
    protected playerController player;
    protected float CurrentVelocity; //玩家当前速度

    protected bool IsAnimationFinshed => stateDuration >= animator.GetCurrentAnimatorStateInfo(0).length;//判断当前动画播发完毕 当前动画状态的长度
    protected float stateDuration => Time.time - stateStartTime;//状态持续时间
    private void OnEnable()
    {
        stateHash = Animator.StringToHash(stateName);//将状态 的名称转变为哈希值
    }

    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="stateMachine"></param>
    public void Initialize(Animator animator, playerController player, PlayerInput inpit, PlayerStateMachine stateMachine)
    {
        this.animator = animator;
        this.player = player;
        this.playerStateMachine = stateMachine;
        this.input = inpit;
    }
    public virtual void Enter()
    {
        animator.CrossFade(stateHash, transitionDuration);
        stateStartTime = Time.time;
    }

    public virtual void Exit()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicUpdate()
    {

    }
}
