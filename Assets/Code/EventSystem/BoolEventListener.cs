using UnityEngine;
using UnityEngine.Events;

public class BoolEventListener : MonoBehaviour
{
    [SerializeField] BoolEventSO boolEventChannel = default;

    [SerializeField] UnityEvent<bool> OnEventRaised;

    public void OnEnable()
    {
        boolEventChannel.OnEventRaised += Respond;
    }
    public void OnDisable()
    {
        boolEventChannel.OnEventRaised -= Respond;
    }
    public void Respond(bool value)
    {
        OnEventRaised?.Invoke(value);
    }
}
