using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "VoidEventSO", menuName = "EventSOs/VoidEventSO")]
public class VoidEventSO : ScriptableObject
{
    public UnityAction OnEventRaise = delegate { };

    public void RaiseEvent()
    {
        OnEventRaise?.Invoke();
    }
}
