using System.Collections;
using SpawningAndEnemies;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
     private bool StartGame = false;
    [SerializeField] private float MaxSpawnRate = 5;
    
    [SerializeField] private GameObject Hoop;
    [SerializeField] private GameObject Enemy;
    [SerializeField] private Vector3 Boundary;
    [SerializeField] private float EnemySpawnRate;
    [SerializeField] private float HoopSpawnRate;
    [SerializeField] private int SpawnerAmount;
    [SerializeField] private float SpawnerPositionSpacing = 0.5f;
     private List<Spawner> spawners = new List<Spawner>();
    //Spawners Reference
    private void OnEnable()
    {
        var viewDistance = 25;
        Boundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, viewDistance));
    }
    public void InitializeLevelGenerator()
    {
        StartGame = true;
    }

    public void KillLevelGenerator()
    {
        StartGame = false;
    }
    private void Start()
    {
        
            LayoutSpawners();
        
    }
    private void Update()
    {
        
    }
    void LayoutSpawners()
    {
        float viewDistance = 150;
        float maxCount = 20;
        float currentCount = 0;
        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height, viewDistance));
        float totalWidth = (Boundary.x - 1) * SpawnerPositionSpacing;
        float totalHeight = (Boundary.y - 1) * SpawnerPositionSpacing;
        float startX = ((screenBounds.x - totalWidth) / 2.0f);
        float startY =  ((screenBounds.y - totalWidth) / 2.0f);
        for (int i = 0; i < Boundary.x; i++)
        {
            for (int j = 0; j < Boundary.y; j++)
            {
                currentCount++;
                float posX =  startX + (i * SpawnerPositionSpacing);
                float posY =  startY + (j * SpawnerPositionSpacing);
               
                var pos =   new Vector3( posX, posY, viewDistance);
                pos.z = viewDistance * 5;
                pos.x = Random.Range(startX,totalWidth/2);
                pos.y = Random.Range(startY, totalHeight / 2);
                var obj = new GameObject();
                obj.transform.position = pos;
                obj.AddComponent<Spawner>();
                obj.AddComponent<ObjectPool>();
                obj.GetComponent<ObjectPool>().SetOBjectToSpawn(Hoop);
                
                spawners.Add(obj.GetComponent<Spawner>());

                if(currentCount > maxCount)
                {
                    return;
                }
                
            }
        
   
        }
       
    }
    
   public void SetSpawnHoop()
    {
        int randomChoice = Random.Range(0, spawners.Count);
        spawners[randomChoice].Pooler.SetOBjectToSpawn(Hoop);
        spawners[randomChoice].SpawnObject();

    }
   public void SetSpawnEnemy()
    {
        int randomChoice = Random.Range(0, spawners.Count);
        spawners[randomChoice].Pooler.SetOBjectToSpawn(Enemy);
        spawners[randomChoice].SpawnObject();
    }
   

   

}
