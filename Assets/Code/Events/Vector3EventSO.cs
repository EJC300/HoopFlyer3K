using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Vector3EventSO", menuName = "EventSOs/Vector3EventSO")]
public class Vector3EventSO : ScriptableObject
{

    public UnityAction<Vector3> OnEventRaised;

    public void RaiseEvent(Vector3 value)
    {
        OnEventRaised?.Invoke(value);
    }
}

