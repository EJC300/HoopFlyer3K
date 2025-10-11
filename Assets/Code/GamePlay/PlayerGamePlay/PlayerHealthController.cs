using Events;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public float Health = 100;
    public FloatEventListener DamageListener;
    public VoidEventListener DeactivatePlayerListener;
    private void Update()
    {
        if(Health < 0)
        {
            Health = 0;
            DeactivatePlayerListener.Respond();
            
        }
    }



}
