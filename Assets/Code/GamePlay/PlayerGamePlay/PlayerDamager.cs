using UnityEngine;

public class PlayerDamager : MonoBehaviour
{

    public float DamageAmount;

    public void OnTriggerEnter(Collider other)
    {
        Transform obj = other.transform.parent.parent;
        if ( obj != null && obj.TryGetComponent(out PlayerHealthController playerHealthController))
        {
            playerHealthController.DamageListener.Respond(DamageAmount);
        }
    }



}
