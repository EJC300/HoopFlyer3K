using System.Collections;
using SpawningAndEnemies;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
     private bool StartGame = false;
    [SerializeField] private int SpawnCount = 100;
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
        var viewDistance = 100;
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
        float viewDistance = 10;
        float offSetX = SpawnerPositionSpacing / Boundary.x;
        float offSetY = SpawnerPositionSpacing / Boundary.y;
        for (int i = 0; i < SpawnCount * 0.5f; i++)
        {
            for (int j = 0; j < SpawnCount * 0.5f; j++)
            {
                float posX = i * (offSetX + 1);
                float posY = j * (offSetY + 1);
               
                var pos = new Vector3(posX, posY, viewDistance);

               
                var obj = new GameObject();
                obj.transform.position = pos;
                obj.AddComponent<Spawner>();
                obj.AddComponent<ObjectPool>();
                obj.GetComponent<ObjectPool>().SetOBjectToSpawn(Hoop);
                
                spawners.Add(obj.GetComponent<Spawner>());
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
