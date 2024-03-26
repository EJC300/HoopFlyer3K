using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HoopController : MonoBehaviour
{
    [SerializeField] private Light greenLight;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            greenLight.gameObject.SetActive(true);

            GameController.instance.Timer += 5;
        }
    }
   

    private void Awake()
    {
       
    }
    private void Update()
    {
        float speed = 25;
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        Destroy(this.gameObject, 10);
    }
}
