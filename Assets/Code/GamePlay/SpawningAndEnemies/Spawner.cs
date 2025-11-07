using Microsoft.Win32.SafeHandles;
using System.Collections;
using UnityEngine;
namespace SpawningAndEnemies
{
    public class Spawner : MonoBehaviour
    {
        public float spawnRate;
        private ObjectPool pooler;
        private bool Fire;
        private Vector3 updatedPosition;
        public ObjectPool Pooler {  get { return pooler; } }
        
     
        private void Start()
        {
            pooler = GetComponent<ObjectPool>();
            if (spawnRate < 0.1)
            {

                spawnRate = Random.value * 10;
                spawnRate = Mathf.Clamp(spawnRate, 5, spawnRate);
            }
            StartCoroutine(Spawn());
        }
        private void OnEnable()
        {
            StartCoroutine(Spawn());
        }
        public void UpdatePosition(Vector3 position)
        {
            Vector3 difference = transform.position - position;
            updatedPosition =transform.position + difference ;
        }
        public void SpawnObjectOfType(Spawn spawn)
        {
            Spawn obj = pooler.GetTypeOfSpawn(spawn);
          
            if (obj != null && Fire && !obj.gameObject.activeInHierarchy)
            {

                obj.gameObject.SetActive(true);
                obj.transform.position = updatedPosition;
                obj.transform.rotation = transform.rotation;
                Fire = false;
            }
        }

        public void SpawnObject()
        {
            Spawn obj = pooler.GetInActiveSpawn();
         
           
            if (obj != null && Fire)
            {

                obj.gameObject.SetActive(true);
                obj.transform.position = transform.position;
                obj.transform.rotation = transform.rotation;
                Fire = false;
            }


        }
        public void UpdatePositionOnOrginShift()
        {
            Spawn obj = pooler.GetInActiveSpawn();
            if(obj != null)
            {
                obj.transform.position = obj.transform.position - updatedPosition;
            }
        }
        public IEnumerator Spawn()
        {
            while (true)
            {
                Fire = true;

                yield return new WaitForSeconds(spawnRate);

             
            }
        }

    }
}
