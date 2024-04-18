using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticFire : MonoBehaviour
{

    [SerializeField] private float fireRate;

    [SerializeField] private GameObject bullet;

    private float nextFire;
    private void Update()
    {
        if(nextFire < Time.time)
        {
            nextFire = Time.time + fireRate/60;

            Instantiate(bullet,transform.position,transform.parent.localRotation);
        }
    }
}
