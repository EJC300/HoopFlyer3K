using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private float speed;   
    private void MoveInDirection()
    {
        transform.Translate(( direction) * speed * Time.deltaTime);
    }
    private void Update()
    {
        MoveInDirection();
      
    }
}
