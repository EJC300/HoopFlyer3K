using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCannon : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float numOfBulletsPerRate;
    [SerializeField] private float fireRate;

    private float nextFire;

    private void Update()
    {
        if (nextFire < Time.time && Input.GetMouseButton(0))
        {
            nextFire = Time.time + numOfBulletsPerRate/fireRate;
            Instantiate(bullet,transform.position,transform.parent.localRotation);
        }
    }
}
