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

        public Transform title;

        [SerializeField] private float SpawnRate;

        public void IncreaseSpawnRate()
        {
            if (SpawnRate > 0.5)
            {
                SpawnRate -= 0.1f;
            }
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
        public IEnumerator DeactivateTitle()
        {
            yield return new WaitForSeconds(5);
            title.gameObject.SetActive(false);
        }
        private void Start()
        {
            StartGameListener.Respond();
            StartCoroutine(SpawnEntityUpdate());
            StartCoroutine(DistanceMultiplier());
            StartCoroutine(DeactivateTitle());
        }
        
        private void Update()
        {

           
            
            
        }
       
     
    }
}
