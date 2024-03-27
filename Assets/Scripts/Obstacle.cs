using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int scoreDetract;
    [SerializeField] private Transform explosion;

    //Maybe should use interfaces with events?
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(explosion,transform.position,Quaternion.identity);
            GameController.instance.Timer -= scoreDetract;
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        Destroy(this.gameObject, 10);
    }
}
