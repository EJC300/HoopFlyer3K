using UnityEngine;
using UnityEngine.Events;
namespace Events
{
    public class VoidEventListener : MonoBehaviour
    {
       public VoidEventSO voidEventChannel = default;

       public UnityEvent OnEventRaised;

        public void OnEnable()
        {
            voidEventChannel.OnEventRaise += Respond;
        }
        public void OnDisable()
        {
            voidEventChannel.OnEventRaise -= Respond;
        }
        public void Respond()
        {
            OnEventRaised?.Invoke();
        }
    }
}
