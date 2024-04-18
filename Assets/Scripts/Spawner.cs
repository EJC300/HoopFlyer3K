using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPrefab;

    [SerializeField] private float spawnRate;

    [SerializeField] private float spawnArea;

    [SerializeField] private float cameraDistance;

    private Vector2 dimension;
    private float nextSpawn;
    private Vector3 spawnPosition;
    private void Awake()
    {
      
     dimension = new Vector2(Screen.width/5, Screen.height/5);


    }
    private void Spawn()
    {

       
       if (nextSpawn < Time.time)
        {
            spawnPosition = new Vector3(Random.value * spawnArea, Random.value * spawnArea,cameraDistance);
   
            spawnPosition.x = Mathf.Clamp(spawnPosition.x, -dimension.x, dimension.x);
            spawnPosition.y = Mathf.Clamp(spawnPosition.y, -dimension.y, dimension.y);
            nextSpawn = Time.time + spawnRate;
            Instantiate(spawnPrefab,transform.position + spawnPosition, Quaternion.identity);
        }
    }
    private void Update()
    {
        Spawn();
    }
}
