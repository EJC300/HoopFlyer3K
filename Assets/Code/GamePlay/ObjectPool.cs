using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject ObjectToSpawn;
    [SerializeField] private int SpawnAmount;

    private List<Spawn> Spawns = new();

    private void Start()
    {
        for (int i = 0; i < SpawnAmount; i++)
        {
            GameObject spawn = Instantiate(ObjectToSpawn);
           
            Spawns.Add(spawn.GetComponent<Spawn>());
            spawn.SetActive(false);
        }
    }

    public Spawn GetInActiveSpawn()
    {
        for (int i = 0; i < Spawns.Count; i++)
        {
            if(!Spawns[i].gameObject.activeInHierarchy)
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
