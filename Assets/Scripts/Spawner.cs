using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPrefab;

    [SerializeField] private float spawnRate;

    private float nextSpawn;
    private void Spawn()
    {
       if(nextSpawn < Time.time)
        {
            nextSpawn = Time.time + spawnRate;
            Instantiate(spawnPrefab, transform.position, Quaternion.identity);
        }
    }
    private void Update()
    {
        Spawn();
    }
}
