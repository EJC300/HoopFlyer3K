using Events;
using UnityEngine;
namespace PlayerGamePlay
{
    public class PlayerDestructor : MonoBehaviour
    {
        public GameObject PlayerHusk;
        private GameObject playerHusk;
        private void Start()
        {
            //playerHusk = Instantiate(PlayerHusk);
           // playerHusk.SetActive(false);

        }

        public void DisablePlayer()
        {
      
           //playerHusk.SetActive(true);
          // playerHusk.transform.position = transform.position;
          // playerHusk.transform.rotation = Quaternion.identity;
          // gameObject.SetActive(false);
        }
    }
}