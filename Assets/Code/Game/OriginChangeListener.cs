using UnityEngine;
using UnityEngine.Events;

public class OriginChangeListener : MonoBehaviour
{
    [SerializeField] Vector3EventSO vector3EventChannel = default;

    [SerializeField] UnityEvent<Vector3> OnEventRaised;

    
   
    public void OnEnable()
    {
        vector3EventChannel.OnEventRaised += Respond;
    }
    public void OnDisable()
    {
        vector3EventChannel.OnEventRaised -= Respond;
    }
    public void Respond(Vector3 value)
    {
        OnEventRaised?.Invoke(value);
    }



}
