
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Events
{
    [CreateAssetMenu(fileName = "LoadLevelSO", menuName = "EventSOs/LoadLevelSO")]
    public class LoadLevelSO : ScriptableObject
    {
        public Scene sceneToLoad;

        public UnityAction<Scene> OnLoadedScene;



        public void RaiseEvent(Scene scene)
        {
            try
            {
                OnLoadedScene?.Invoke(scene);
            }
            catch
            {


            }


        }



    }
}
