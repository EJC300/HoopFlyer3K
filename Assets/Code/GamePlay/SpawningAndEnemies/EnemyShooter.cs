using SpawningAndEnemies;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{

    public Blasters blaster;

    private void Update()
    {
        blaster.Fire(true);
    }

}
