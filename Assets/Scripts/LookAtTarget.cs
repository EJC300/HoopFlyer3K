using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {

        Vector3 direction = transform.position - target.position;

        float dot = Vector3.Dot(direction, target.forward);
        if (dot > 0 && direction.magnitude > 0.5f)
        {
            transform.rotation = QuasarMath.SlerpLookAt(transform.rotation, Vector3.zero, direction.normalized, speed * direction.magnitude, Time.deltaTime);
        }
    }
}
