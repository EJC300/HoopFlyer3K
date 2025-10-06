using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private Vector3 startPos;
    private Quaternion startRotation;
    [SerializeField] private float deactivateTime;

 
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
    private void Start()
    {
        StartCoroutine(DeactivateByTime(deactivateTime));
    }
    public IEnumerator DeactivateByTime(float delay)
    {
       
        yield return new WaitForSeconds(delay);
       
         gameObject.SetActive(false);
        
    }

}
