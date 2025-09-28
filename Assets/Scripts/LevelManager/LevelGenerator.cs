using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManager
{
    public class LevelGenerator : MonoBehaviour
    {
        public float viewDistance;

        public int spawnCount;

        public float spawnRate;

        

        public GameObject Enemy;

        public GameObject Hoop;

        public GameObject Asteroid;
        
        private GameObject previousSpawn;

        Vector3 spawnPos = Vector3.zero;

        private static  Vector3 delta;

       public List<GameObject> spawnableList = new();
        private void Start()
        {
            FillList();
            SpawnAtRate();
        }

        public static void SetDelta(Vector3 pos)
        {
            delta =  Vector3.zero - pos;
        }
        void FillList()
        {
            for (int i = 0; i < spawnCount; i++)
            {

                spawnableList.Add(Enemy);
                spawnableList.Add(Hoop);
                spawnableList.Add(Asteroid);
            }
        }
      

       

        void SpawnAtRandomPoint()
        {
            

            GameObject objectToSpawn = spawnableList[Random.Range(0,spawnCount)];
            Debug.Log(objectToSpawn);
           


            spawnPos.x = Random.value * 70 - Random.value * -70;
            spawnPos.y = Random.value * 70 - Random.value * -70;
            spawnPos.z = transform.parent.position.z + 100;
          

         
            previousSpawn = spawnableList[0];
            if(objectToSpawn.name == previousSpawn.name)
            {
                objectToSpawn = previousSpawn;
                
            }

            Instantiate(objectToSpawn,spawnPos + delta,Quaternion.identity);
            previousSpawn = objectToSpawn;


        }

        public void SpawnAtRate()
        {
            StartCoroutine(SpawnLevelObjects());
        }

       private IEnumerator SpawnLevelObjects()
        {
            while (true)
            {
                SpawnAtRandomPoint();

                yield return new WaitForSeconds(spawnRate);

            }
        }

     
    }
}
