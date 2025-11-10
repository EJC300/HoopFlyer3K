using UnityEngine;

public class DeactivateOnInvisible : MonoBehaviour
{
   
    public GameObject parent;

    public void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
