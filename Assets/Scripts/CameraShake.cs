using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float shakeDuration;
    [SerializeField] private float shakeScale;
    [SerializeField] private float shakeSpeed;
    private float seconds;

    public void Shake()
    {
        Vector3 camPos = transform.position;
        if (seconds > 0)
        {
           camPos.x += Mathf.Sin(Time.time * shakeSpeed) * shakeScale;
           camPos.y += Mathf.Cos(Time.time * shakeSpeed) * shakeScale;
        }
        else
        {
            seconds = shakeDuration;
        }
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + camPos.x, Camera.main.transform.position.y + camPos.y,Camera.main.transform.position.z);
    }
}
