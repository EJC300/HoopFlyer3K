using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HoopController : MonoBehaviour
{
    [SerializeField] private Light greenLight;
    [SerializeField] private Material shockWave;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
           
            greenLight.gameObject.SetActive(true);

            other.GetComponent<PlayerController>().Health.IncreaseFuel(5);
          
        }
    }

    private void Start()
    {
   
    }
    private void Update()
    {
       
        Destroy(this.gameObject, 10);
    }
}
