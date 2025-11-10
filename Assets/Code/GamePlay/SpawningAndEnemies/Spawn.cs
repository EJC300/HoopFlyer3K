using System.Collections;
using UnityEngine;
namespace SpawningAndEnemies
{
    public class Spawn : MonoBehaviour
    {
        private Vector3 startPos;
        private Quaternion startRotation;
       // [SerializeField] private float deactivateTime;
        public GameObject root;
        //private float prevDeactivationTime;

        private void Awake()
        {
          //  prevDeactivationTime = deactivateTime;
        }
        public void OnEnable()
        {
            
            startPos = transform.position;
            startRotation = transform.rotation;
        }

        public void OnDisable()
        {
            transform.position = startPos;
            transform.rotation = startRotation;
            
            
        }
      
        /*
        public IEnumerator DeactivateByTime(float delay)
        {
            while (true)
            {
                yield return new WaitForSeconds(delay);

                gameObject.SetActive(false);

            }
        }
        */

    }
}
