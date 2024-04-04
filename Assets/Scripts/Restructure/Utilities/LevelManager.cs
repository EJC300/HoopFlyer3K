using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace Utilities
{
    public class LevelManager : Singleton<LevelManager>
    {
        [SerializeField] private float fadeSpeed;
        private Image fadeOutImage;
        private bool doneTransitioning;
       
        private void Update()
        {
            Transition();
        }
        private void Transition()
        {
            if (fadeOutImage == null)
            {
                fadeOutImage = GameObject.FindAnyObjectByType<Image>();
            }
            if (fadeOutImage.color.a > 0 && fadeOutImage != null)
            {
                Color fadeImageColor = fadeOutImage.color;
                fadeImageColor.a = Mathf.MoveTowards(fadeOutImage.color.a, 0, Time.deltaTime * fadeSpeed);
                fadeOutImage.color = fadeImageColor;
            }
            else
            {
                doneTransitioning = true;
            }
        }
        public void LoadScene(int buildIndex)
        {
          

            if(doneTransitioning)
            {
                doneTransitioning = false;
               
                SceneManager.LoadScene(buildIndex);
                   
             
               
            }
            
        }

     
    }
}