using UnityEngine;
using UnityEngine.Events;
namespace Events
{
    public class IntEventListener : MonoBehaviour
    {
        [SerializeField] IntEventSO intEventChannel = default;

        [SerializeField] UnityEvent<int> OnEventRaised;

        public void OnEnable()
        {
            intEventChannel.OnEventRaised += Respond;
        }
        public void OnDisable()
        {
            intEventChannel.OnEventRaised -= Respond;
        }
        public void Respond(int value)
        {
            OnEventRaised?.Invoke(value);
        }
    }
}
