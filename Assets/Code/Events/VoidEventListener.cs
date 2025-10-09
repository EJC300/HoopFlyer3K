using UnityEngine;
using UnityEngine.Events;
namespace Events
{
    public class VoidEventListener : MonoBehaviour
    {
       public VoidEventSO voidEventChannel = default;

       public UnityEvent OnEventRaised;

        private void OnEnable()
        {
            voidEventChannel.OnEventRaised += Respond;
        }
        private void OnDisable()
        {
            voidEventChannel.OnEventRaised -= Respond;
        }
       public void Respond()
        {
            OnEventRaised?.Invoke();
        }
    }
}
