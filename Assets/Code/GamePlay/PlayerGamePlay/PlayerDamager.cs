using UnityEngine;

public class PlayerDamager : MonoBehaviour
{

    public float DamageAmount;

    public void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerHealthController playerHealthController))
        {
            playerHealthController.DamageListener.Respond(DamageAmount);
        }
    }



}
