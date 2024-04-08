using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
    [SerializeField]
    private float tumble;

    void Update()
    {
       transform.Rotate((Vector3.right + Vector3.up + Vector3.forward) * tumble,Space.Self);
    }
}