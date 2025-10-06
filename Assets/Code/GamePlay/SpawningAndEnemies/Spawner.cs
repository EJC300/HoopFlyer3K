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
            if (spawnRate < 1)
            {

                spawnRate = Random.value;
            }
        }

        public void SpawnObject()
        {
            Spawn obj = pooler.GetInActiveSpawn();
            StartCoroutine(Spawn());
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
            yield return new WaitForSeconds(spawnRate);

            Fire = true;
        }

    }
}
