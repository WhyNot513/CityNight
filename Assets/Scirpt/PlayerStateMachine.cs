using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerStateMachine : StateMachine
{


    [SerializeField] PlayStateManger[] states; //集合形数据

    [SerializeField] PlayerInput input;

    playerController player;
    Animator animator;
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        player = GetComponent<playerController>();
        //初始化玩家的其他状态
        statesTable = new Dictionary<System.Type, IState>(states.Length);//初始化状态字典
        foreach (PlayStateManger item in states)
        {
            item.Initialize(animator, player, input, this);
            statesTable.Add(item.GetType(), item);
        }
    }

    private void Start()
    {

        SwitchOn(statesTable[typeof(PlayerState_Idle)]);//玩家一开始就是已空闲状态启动
    }
}
