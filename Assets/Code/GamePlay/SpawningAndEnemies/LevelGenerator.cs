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
    [SerializeField] private List<Spawner> spawners = new List<Spawner>();
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
    void LayoutSpawners()
    {
        float viewDistance = 100;
        float offSetX = SpawnerPositionSpacing / Boundary.x;
        float offSetY = SpawnerPositionSpacing / Boundary.y;
        for (int i = 0; i < Boundary.x; i++)
        {
            for (int j = 0; j < Boundary.y; j++)
            {
                float posX = i + (offSetX + 1);
                float posY = j + (offSetY + 1);
                posX *= Random.value;
                posY *= Random.value;
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
    void SetSpawnHoop()
    {
        int randomChoice = Random.Range(0, spawners.Count);
  
        spawners[randomChoice].Spawn();
    }
    void SetSpawnEnemy()
    {
        int randomChoice = Random.Range(0, spawners.Count);
        spawners[randomChoice].Pooler.SetOBjectToSpawn(Enemy);
        spawners[randomChoice].Spawn();
    }
    public void SpawnEnemy()
    {
        if (StartGame)
        {
            StartCoroutine(SpawnEnemyByRate());
        }
    }
    public void SpawnHoop()
    {
        if (StartGame)
        {
            StartCoroutine(SpawnHoopByRate());
        }
    }
    IEnumerator SpawnHoopByRate()
    {
        yield return new WaitForSeconds(HoopSpawnRate);
        SetSpawnHoop();
    }
    IEnumerator SpawnEnemyByRate()
    {
        yield return new WaitForSeconds(EnemySpawnRate);
        SetSpawnEnemy();
    }
}
