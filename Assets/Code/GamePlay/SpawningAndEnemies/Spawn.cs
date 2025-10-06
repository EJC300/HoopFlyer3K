using System.Collections;
using UnityEngine;
namespace SpawningAndEnemies
{
    public class Spawn : MonoBehaviour
    {
        private Vector3 startPos;
        private Quaternion startRotation;
        [SerializeField] private float deactivateTime;


        public void OnEnable()
        {
            StartCoroutine(DeactivateByTime(deactivateTime));
            startPos = transform.position;
            startRotation = transform.rotation;
        }

        public void OnDisable()
        {
            transform.position = startPos;
            transform.rotation = startRotation;
        }

        public IEnumerator DeactivateByTime(float delay)
        {

            yield return new WaitForSeconds(delay);

            gameObject.SetActive(false);

        }

    }
}
