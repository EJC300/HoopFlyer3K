using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int scoreDetract;
    [SerializeField] private Transform explosion;
    [SerializeField] private float damageAmount;
    //Maybe should use interfaces with events?
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(explosion,transform.position,Quaternion.identity);
          

            Destroy(this.gameObject,0);
        }
        if(other.gameObject.TryGetComponent<IDamagable>(out IDamagable damage))
        {
            damage.Damage(damageAmount);
        }
    }
    private void Update()
    {
        Destroy(this.gameObject, 10);
    }
}
