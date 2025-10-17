using System.Collections.Generic;
using UnityEngine;
namespace SpawningAndEnemies
{
    public class ObjectPool : MonoBehaviour
    {
        public GameObject ObjectToSpawn;
        [SerializeField] private int SpawnAmount;

        
       [SerializeField] private List<Spawn> Spawns = new();

        public void SetOBjectToSpawn(GameObject spawn)
        {
                if(SpawnAmount < 1)
                {
                 SpawnAmount = 100;
                }
                ObjectToSpawn = spawn;
            
        }
        
        public void InstanceNewObject()
        {
            for (int i = 0; i < SpawnAmount; i++)
            {
                GameObject spawn = Instantiate(ObjectToSpawn);
                spawn.name = spawn.name + i;
                Spawns.Add(spawn.GetComponent<Spawn>());
                spawn.SetActive(false);
            }
        }
        private void Start()
        {
          InstanceNewObject();
        }


        public Spawn GetSpawnAtIndex(int index)
        {
            return Spawns[index];
        }

        public Spawn GetTypeOfSpawn(Spawn spawn)
        {
            for(int i = 0;i < Spawns.Count;i++)
            {
                if (Spawns[i].gameObject.name + i == spawn.gameObject.name + i)
                {
                    if (!Spawns[i].gameObject.activeInHierarchy)
                    {
                        return Spawns[i];
                    }
                }
            
            }
            return null;
        }

        public Spawn GetInActiveSpawn()
        {
            for (int i = 0; i < Spawns.Count; i++)
            {
                if (!Spawns[i].gameObject.activeInHierarchy)
                {
                    return Spawns[i];
                }
            }
            return null;
        }

        public void SetSpawnActive()
        {
            for (int i = 0; i < Spawns.Count; i++)
            {
                if (!Spawns[i].gameObject.activeInHierarchy)
                {
                    Spawns[i].gameObject.SetActive(true);
                }
            }
        }

        public void SetSpawnInActive()
        {
            for (int i = 0; i < Spawns.Count; i++)
            {
                if (Spawns[i].gameObject.activeInHierarchy)
                {
                    Spawns[i].gameObject.SetActive(false);
                }
            }
        }
    }
}
