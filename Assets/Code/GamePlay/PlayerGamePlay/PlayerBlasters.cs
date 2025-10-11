using UnityEngine;
using SpawningAndEnemies;
using Events;
namespace PlayerGamePlay
{
    public class PlayerBlasters : MonoBehaviour
    {
        [SerializeField] private PlayerControls controls = default;
        private bool StartGame = false;
        private bool fire = false;
        private Blasters blasters;
        public void InitializeBlasters()
        {
            StartGame = true;
        }

        private void Start()
        {
            blasters = GetComponent<Blasters>();
        }

        private void Update()
        {
            blasters.Fire(fire);
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
            if (StartGame && !fire)
            {
                fire = true;
               
            }
        }
        void StopFire()
        {
            if (StartGame && fire)
            {

              fire= false;
            }
        }

      
    }
}
