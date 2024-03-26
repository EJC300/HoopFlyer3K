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
        Vector3 direction =  new Vector3(x,y,transform.localPosition.z);
         
         transform.localPosition = direction; 
    }
}
