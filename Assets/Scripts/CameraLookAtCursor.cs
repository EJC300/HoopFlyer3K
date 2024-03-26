using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraLookAtCursor : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private Transform target;

    [SerializeField]  private Vector3 offset;

    private void Start()
    {
        offset = Camera.main.transform.position;    
    }
    public void LookAtMouse(Vector3 mousePosition)
    {
        Camera.main.transform.position =  target.position + offset;
        Vector3 heading = (mousePosition - Camera.main.transform.position);
        float lookAheadDistance = 25;
        heading = new Vector3(heading.x, heading.y, lookAheadDistance);
        float speed = 5;
        Camera.main.transform.localRotation = QuasarMath.SlerpLookAt(Camera.main.transform.localRotation,Camera.main.transform.position, heading, speed, Time.deltaTime);


    }
    
}
