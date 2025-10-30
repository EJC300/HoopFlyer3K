using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
  
    void Update()
    {
        Destroy(this.gameObject,0.5f);
    }
}
