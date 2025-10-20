using UnityEngine;

public class PlayerRefuel : MonoBehaviour
{

    public float FuelAmount;

    public void OnTriggerEnter(Collider other)
    {
        Transform obj = other.transform.parent.parent;
        if (obj != null && obj.TryGetComponent(out PlayerFuelController playerFuelController))
        {
            playerFuelController.FuelListener.Respond(FuelAmount);
        }
    }
}
