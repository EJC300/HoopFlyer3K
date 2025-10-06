using UnityEngine;
using SpawningAndEnemies;
using Events;
namespace PlayerGamePlay
{
    public class PlayerBlasters : MonoBehaviour
    {
        [SerializeField] private PlayerControls controls = default;
        private bool StartGame = false;
        private Blasters blasters;
        public void InitializeBlasters()
        {
            StartGame = true;
        }

        private void Start()
        {
            blasters = GetComponent<Blasters>();
        }

        private void OnEnable()
        {
            controls.MouseEventFire += Fire;
            controls.MouseEventFireCancled += StopFire;
        }

        private void OnDisable()
        {
            controls.MouseEventFire -= Fire;
            controls.MouseEventFireCancled -= StopFire;
        }
        void Fire()
        {
            if (StartGame)
            {
                blasters.Fire(true);
            }
        }
        void StopFire()
        {
            if (StartGame)
            {

                blasters.Fire(false);
            }
        }

      
    }
}
