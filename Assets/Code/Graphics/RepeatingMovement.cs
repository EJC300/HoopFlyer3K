using UnityEngine;

public class RepeatingMovement : MonoBehaviour
{

    public float speed = 500;
    public float maxDistance = 4000;

    void Update()
    {
     
      if(Mathf.Abs( transform.localPosition.z) > maxDistance )
        {
            transform.localPosition = Vector3.zero;
        }
        transform.Translate(Vector3.forward * -speed * Time.deltaTime);
    }
}
