using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    // Start is called before the first frame update
    IState currentState;
    protected Dictionary<System.Type, IState> statesTable;
    private void Update()
    {
        currentState.LogicUpdate();
    }
    private void FixedUpdate()
    {
        currentState.PhysicUpdate();
    }
    protected void SwitchOn(IState newIState)
    {
        currentState = newIState;
        currentState.Enter();
    }
    public void SwitchState(IState newState)
    {
        currentState.Exit();
        SwitchOn(newState);
    }

    /// <summary>
    /// 先从根据传入的Type在字典中找到相对于的转台 
    /// </summary>
    /// <param name="newStateType"></param>
    public void SwitchState(System.Type newStateType)
    {
        SwitchState(statesTable[newStateType]);
    }
}
