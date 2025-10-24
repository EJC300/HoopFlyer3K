using UnityEngine;
namespace Player
{
    public class PlayerGameControllerLevel : MonoBehaviour
    {


        public Transform PauseScreen;

        public float Distance;

        private float CurrentDistance;


        public void SetPauseScreenActive()
        {
            PauseScreen.gameObject.SetActive(!PauseScreen.gameObject.activeInHierarchy);
        }

        public void RecordDistance(float newDistance)
        {
          CurrentDistance += newDistance;
        }

        public void SaveDistanceTraveled()
        {
            Distance = CurrentDistance;
            PlayerPrefs.SetFloat("Distance Traveled",Distance);
        }
    

    }
}