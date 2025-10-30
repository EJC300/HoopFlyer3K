using UnityEngine;
using Events;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

namespace PlayerGamePlay {
    public class GameManager : MonoBehaviour
    {
        public VoidEventListener StartGameListener;
        public VoidEventListener DistanceMulitplierListener;
        public VoidEventListener SpawnEntities;
        
        

        [SerializeField] private float SpawnRate;

        public void IncreaseSpawnRate()
        {
            SpawnRate -= 0.1f;
        }

        public IEnumerator SpawnEntityUpdate()
        {
            while (true)
            {
                yield return new WaitForSeconds(SpawnRate);
                SpawnEntities.Respond();
            }
        }

        public IEnumerator DistanceMultiplier()
        {
            
            float rate = 10;
            while(true)
            {
                yield return new WaitForSeconds(rate);
                DistanceMulitplierListener.Respond();
            }
        }

        private void Start()
        {
            StartGameListener.Respond();
            StartCoroutine(SpawnEntityUpdate());
            StartCoroutine(DistanceMultiplier());
        }
        
        private void Update()
        {

            
            
            
        }
       
     
    }
}
