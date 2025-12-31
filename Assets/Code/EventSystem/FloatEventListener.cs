using UnityEngine;
using UnityEngine.Events;
namespace Events
{
    public class FloatEventListener : MonoBehaviour
    {
        [SerializeField] FloatEventSO floatEventChannel = default;

        [SerializeField] UnityEvent<float> OnEventRaised;

        public void OnEnable()
        {
            floatEventChannel.OnEventRaised += Respond;
        }
        public void OnDisable()
        {
            floatEventChannel.OnEventRaised -= Respond;
        }
        public void Respond(float value)
        {
            OnEventRaised?.Invoke(value);
        }
    }
}