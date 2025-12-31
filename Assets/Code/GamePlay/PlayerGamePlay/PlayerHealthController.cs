using Events;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthController : MonoBehaviour
{
    public float Health = 100;
    public Slider HealthSlider;
    public FloatEventListener DamageListener;
    public VoidEventListener DeactivatePlayerListener;
    public CameraShake camera;
    private void Update()
    {
        HealthSlider.value = Health;
        if(Health < 0)
        {
            Health = 0;
            DeactivatePlayerListener.Respond();
            
        }
    }

    public void Damage(float damage)
    {
        Health -= damage;
        camera.TriggerShake();

    }
    public void Repair()
    {
        if (Health < 100)
        {
            Health = 100;
           
        }
    }
}
