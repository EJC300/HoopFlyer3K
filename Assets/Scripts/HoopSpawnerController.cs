using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopSpawnerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float scaleX,scaleY;


    private void Update()
    {
        if (GameController.instance.isLoaded)
        {
            float x = Mathf.Sin(speed * Time.time) * scaleX;
          
            float y = Mathf.Sin(speed * Time.time) * scaleY;
       
            Vector3 screenDimensions = Camera.main.ViewportToWorldPoint(new Vector3((Screen.width - scaleX)/Screen.width, (Screen.height - scaleY)/Screen.height, 0));
            float boundX = Mathf.Clamp(x, -screenDimensions.x, screenDimensions.x);
            float boundY = Mathf.Clamp(y, -screenDimensions.y, screenDimensions.y);
            float px = Random.Range(-boundX, boundX);
            float py = Random.Range(-boundY, boundY);
            Vector3 direction = (new Vector3(px, py, transform.localPosition.z));

            transform.localPosition = direction;
        }
    }
}
