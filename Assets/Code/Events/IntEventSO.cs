using UnityEngine;
using UnityEngine.Events;
namespace Events
{
    [CreateAssetMenu(fileName = "IntEventSO", menuName = "EventSOs/IntEventSO")]
    public class IntEventSO : ScriptableObject
    {
        public UnityAction<int> OnEventRaised;

        public void RaiseEvent(int value)
        {
            OnEventRaised?.Invoke(value);
        }
    }
}