using System;
using UnityEngine;
using UnityEngine.Events;
namespace Events
{
    [CreateAssetMenu(fileName = "VoidEventSO", menuName = "EventSOs/VoidEventSO")]

    public class VoidEventSO : ScriptableObject
    {
        public UnityAction OnEventRaised;

        public void RaiseEvent()
        {
            OnEventRaised?.Invoke();
        }
    }
}