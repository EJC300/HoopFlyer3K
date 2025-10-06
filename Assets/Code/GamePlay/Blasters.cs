using System.Collections.Generic;
using UnityEngine;

public class Blasters : MonoBehaviour
{

    [SerializeField] private List<Spawner> blasters = new();

    public void Fire(bool fire)
    {
        foreach (Spawner s in blasters)
        {

            if (fire)
            {
                s.SpawnObject();
            }
          
        }
    }



}
