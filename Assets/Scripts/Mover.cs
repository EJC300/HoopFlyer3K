using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float speed;

    public float Speed { get => speed; set => speed = value; }

    private void Update()
    {
       transform.Translate(Vector3.forward * Speed * Time.deltaTime,Space.World);
    }
}
