using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopSpawnerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float scaleX,scaleY;


    private void Update()
    {
        
        float x = Mathf.Sin(speed * Time.time) * scaleX;
        x =  Random.Range(-x,x);
        float y = Mathf.Sin(speed * Time.time) * scaleY;
        y = Random.Range(-y, y);
        Vector3 screenDimensions = Camera.main.ViewportToWorldPoint(new Vector3(Screen.width - scaleX, Screen.height - scaleY, 0));
        float boundX = Mathf.Clamp(x, -screenDimensions.x, screenDimensions.x);
        float boundY = Mathf.Clamp(y, -screenDimensions.y, screenDimensions.y);
        Vector3 direction = ( new Vector3(boundX,boundY,transform.localPosition.z));
         
        transform.localPosition = direction; 
    }
}
