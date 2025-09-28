using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraLookAtCursor : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private Transform target;

    [SerializeField]  private Vector3 offset;

    private Vector3 delta;
    private bool updated;
    private void Start()
    {
        offset = Camera.main.transform.position;    
    }
    private void OnEnable()
    {
        WorldBoundsFix.OnOriginShift += UpdateOrigin;
    }
    private void OnDisable()
    {
        WorldBoundsFix.OnOriginShift -= UpdateOrigin;
    }
    void UpdateOrigin(Vector3 referencePos)
    {
        delta = referencePos - Vector3.zero;
        Camera.main.transform.position -= delta;
        updated = true;
    }
    public void LookAtMouse(Vector3 mousePosition)
    {
        if (updated)
        {
            updated = false;
        }
        if (!updated)
        {
          
            Camera.main.transform.position = QuasarMath.SmoothDamp(Camera.main.transform.position + delta, target.position + offset + delta, 3.5f, Time.deltaTime);
            Vector3 heading = (mousePosition - Camera.main.transform.position);
            float lookAheadDistance = 25;
            heading = new Vector3(heading.x, heading.y, lookAheadDistance);
            float speed = 1.5f;
            Camera.main.transform.localRotation = QuasarMath.SlerpLookAt(Camera.main.transform.localRotation, Camera.main.transform.position, heading, speed, Time.deltaTime);
        }

    }
    
}
