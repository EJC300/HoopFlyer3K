using System.Collections;
using SpawningAndEnemies;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using System.Drawing;
using UnityEditor.Experimental.GraphView;

public class LevelGenerator : MonoBehaviour
{
     private bool StartGame = false;
    private Vector3 updatedOrigin;
    [SerializeField] private float MaxSpawnRate = 5;
    
    [SerializeField] private GameObject Hoop;
    [SerializeField] private GameObject Enemy;
    [SerializeField] private GameObject Asteroid;
    [SerializeField] private Vector3 Boundary;
    [SerializeField] private float EnemySpawnRate;
    [SerializeField] private float HoopSpawnRate;
    [SerializeField] private int SpawnerAmount;
    [SerializeField] private float SpawnerPositionSpacing = 5.5f;
    [SerializeField] private List<Spawner> spawners = new List<Spawner>();
    //Spawners Reference
    private void OnEnable()
    {
        var viewDistance = 25;
        Boundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, viewDistance));
        LayoutSpawners();

    }
    public void InitializeLevelGenerator()
    {
        StartGame = true;
    }

    public void KillLevelGenerator()
    {
        StartGame = false;
    }
    public void UpdatedOrigin(Vector3 position)
    {
        updatedOrigin = position;
    }
    void LayoutSpawners()
    {
        float viewDistance = 150;
        float maxCount = 200;
        float currentCount = 0;
        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height, viewDistance)) * 0.5f;
    

       
        for (int i = 0; i < Boundary.x; i++)
        {
            for (int j = 0; j < Boundary.y; j++)
            {
                currentCount++;
                float posX =  (i) * 2;
                float posY =   (j) * 2;
               
                var pos =   new Vector3( posX, posY, viewDistance);
                pos.z = viewDistance * 5;
               // pos.x = Random.Range(startX,totalWidth/2);
               // pos.y = Random.Range(startY, totalHeight / 2);
                var obj = new GameObject();
                obj.transform.position = pos;
                obj.AddComponent<Spawner>();
                obj.AddComponent<ObjectPool>();
                obj.GetComponent<ObjectPool>().SetOBjectToSpawn(Enemy);
                obj.GetComponent<ObjectPool>().InstanceNewObject();
                obj.GetComponent<ObjectPool>().SetOBjectToSpawn(Asteroid);
                obj.GetComponent<ObjectPool>().InstanceNewObject();
                obj.GetComponent<ObjectPool>().SetOBjectToSpawn(Hoop);
                spawners.Add(obj.GetComponent<Spawner>());

               if(spawners.Count > maxCount)
                {
                    return;
                }
                
            }
        
   
        }
  
    }
    
   public void SetSpawnHoop()
    {
        int randomChoice = Random.Range(0, spawners.Count);
        float spawnRate = Random.value * HoopSpawnRate;
        spawnRate = Mathf.Clamp(spawnRate, HoopSpawnRate * 1.5f, HoopSpawnRate);
        if (spawners[randomChoice].spawnRate != spawnRate)
        {
            spawners[randomChoice].spawnRate = spawnRate;
            spawners[randomChoice].UpdatePosition(updatedOrigin);
            spawners[randomChoice].SpawnObjectOfType(Hoop.GetComponent<Spawn>());
            //UpdatePosition
            
        }
       // spawners[randomChoice].SpawnObject();
        

    }
   public void SetSpawnEnemy()
    {
        int randomChoice = Random.Range(0, spawners.Count);
        float spawnRate = Random.value * EnemySpawnRate;
        spawnRate = Mathf.Clamp(spawnRate, EnemySpawnRate * 1.5f, EnemySpawnRate);
      
        if (spawners[randomChoice].spawnRate != spawnRate)
        {
            spawners[randomChoice].spawnRate = spawnRate;
            spawners[randomChoice].UpdatePosition(updatedOrigin);
            spawners[randomChoice].SpawnObjectOfType(Enemy.GetComponent<Spawn>());
            //UpdatePosition
        }

    }

    public void SetSpawnAsteroid()
    {
        int randomChoice = Random.Range(0, spawners.Count);
        float spawnRate = Random.value * HoopSpawnRate;
        spawnRate = Mathf.Clamp(spawnRate, HoopSpawnRate * 1.5f, HoopSpawnRate);
        if (spawners[randomChoice].spawnRate != spawnRate)
        {
            spawners[randomChoice].spawnRate = spawnRate;
            spawners[randomChoice].UpdatePosition(updatedOrigin);
            spawners[randomChoice].SpawnObjectOfType(Asteroid.GetComponent<Spawn>());
            //UpdatePosition
        }


    }
   

}
