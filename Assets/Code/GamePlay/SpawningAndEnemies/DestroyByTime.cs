using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
  
    void Update()
    {
        Destroy(this.gameObject,1.5f);
    }
}
