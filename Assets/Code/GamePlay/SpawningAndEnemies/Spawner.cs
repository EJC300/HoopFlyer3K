using System.Collections;
using UnityEngine;
namespace SpawningAndEnemies
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private float spawnRate;
        private ObjectPool pooler;
        private bool Fire;
        public ObjectPool Pooler {  get { return pooler; } }

        private void Start()
        {
            pooler = GetComponent<ObjectPool>();
            if (spawnRate < 0.1)
            {

                spawnRate = Random.value * 10;
                spawnRate = Mathf.Clamp(spawnRate,5,spawnRate);
            }
            StartCoroutine(Spawn());
        }

        public void SpawnObjectOfType(Spawn spawn)
        {
            Spawn obj = pooler.GetTypeOfSpawn(spawn);
          
            if (obj != null && Fire)
            {

                obj.gameObject.SetActive(true);
                obj.transform.position = transform.position;
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
        public IEnumerator Spawn()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnRate);

                Fire = true;
            }
        }

    }
}
