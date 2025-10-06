using UnityEngine;
using UnityEngine.Events;
namespace Events
{
    [CreateAssetMenu(fileName = "BoolEventSO", menuName = "EventSOs/BoolEventSO")]
    public class BoolEventSO : ScriptableObject
    {
        public UnityAction<bool> OnEventRaised;

        public void RaiseEvent(bool value)
        {
            OnEventRaised?.Invoke(value);
        }
    }
}