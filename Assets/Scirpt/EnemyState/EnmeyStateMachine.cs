using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnmeyStateMachine : StateMachine
{
    [SerializeField] EnemyStateManger[] states; //集合形数据



    EnemyControl enemy;
    Animator animator;
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        enemy = GetComponent<EnemyControl>();
        //初始化怪物的其他状态
        statesTable = new Dictionary<System.Type, IState>(states.Length);//初始化状态字典
        foreach (EnemyStateManger item in states)
        {
            item.Initialize(animator, enemy, this);
            statesTable.Add(item.GetType(), item);
        }
    }

    private void Start()
    {
        SwitchOn(statesTable[typeof(PlayerState_Idle)]);//玩家一开始就是已空闲状态启动
    }
}
