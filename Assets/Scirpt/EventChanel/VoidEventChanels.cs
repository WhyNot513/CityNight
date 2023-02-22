using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Date/EventChanels/VoidEventChanels", fileName = "VoidEventChanels_")]
public class VoidEventChanels : ScriptableObject
{
    event System.Action Delegate;

    public void Broadcast()
    {
        Delegate?.Invoke();
    }
    public void AddListener(System.Action action)
    {
        Delegate += action;
    }
    public void RemoveListener(System.Action action)
    {
        Delegate -= action;
    }
}
