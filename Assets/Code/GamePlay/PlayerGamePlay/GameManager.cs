using UnityEngine;
using Events;
using System.Collections;

namespace PlayerGamePlay {
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private VoidEventListener StartGameListener;
        [SerializeField] private VoidEventListener SpawnEntities;
        [SerializeField] private float SpawnRate;
        private void Start()
        {
            StartGameListener.Respond();
            
        }
        private void LateUpdate()
        {
            StartCoroutine(SpawnEntitiesByRate());
        }
        public IEnumerator SpawnEntitiesByRate()
        {
            yield return new WaitForSeconds(SpawnRate);
          
            SpawnEntities.Respond();
        }
    }
}
