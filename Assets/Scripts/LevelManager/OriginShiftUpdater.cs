using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LevelManager
{
    public class OriginShiftUpdater : MonoBehaviour
    {


        public void OnEnable()
        {
            WorldBoundsFix.OnOriginShift += UpdateOrigin;
        }
        public void OnDisable()
        {
            WorldBoundsFix.OnOriginShift -= UpdateOrigin;
        }
        void UpdateOrigin(Vector3 referencedPos)
        {
            Debug.Log("Shifted AWoo");

            transform.position = transform.position + (Vector3.zero - referencedPos);
            Vector3 direction = (transform.position - referencedPos).normalized;

            bool behind = Vector3.Dot(direction,transform.forward) > 0;
            
            if (behind)
            {
                Destroy(gameObject);
            }
        }
    }
}