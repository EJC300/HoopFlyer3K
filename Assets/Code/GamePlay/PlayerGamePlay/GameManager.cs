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


        public IEnumerator SpawnEntityUpdate()
        {
            while (true)
            {
                yield return new WaitForSeconds(SpawnRate);
                SpawnEntities.Respond();
            }
        }



        private void Start()
        {
            StartGameListener.Respond();
            StartCoroutine(SpawnEntityUpdate());
        }
        
        private void Update()
        {


            
        }
       
     
    }
}
