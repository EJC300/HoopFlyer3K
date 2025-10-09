using UnityEngine;
using Events;
using System.Collections;
using UnityEngine.Windows;

namespace PlayerGamePlay {
    public class GameManager : MonoBehaviour
    {
        public VoidEventListener StartGameListener;
        public VoidEventListener SpawnEntities;
        [SerializeField] private float SpawnRate;
        private void Start()
        {
            StartGameListener.Respond();
            SpawnEntities.Respond();
        }
        
        private void Update()
        {
          
                
            
        }
        public void TestMYButt()
        {
            Debug.Log("BUTT");
        }
        public IEnumerator SpawnEntitiesByRate()
        {
            yield return new WaitForSeconds(SpawnRate);
           
            
        }
    }
}
