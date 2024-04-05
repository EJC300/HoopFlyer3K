using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace Utilities
{
    public class LevelManager : Singleton<LevelManager>
    {
        [SerializeField] private float fadeSpeed;
        private Image fadeOutImage;
        private bool doneTransitioning;
        //Fix This
        Color fadeImageColor;
        private void Update()
        {
            
            Transition();
            
        }
        private void Start()
        {
           
        }
        private void Transition()
        {
            if (fadeOutImage == null)
            {
                fadeOutImage = GameObject.FindAnyObjectByType<Image>();
            }
            fadeImageColor = fadeOutImage.color;
            if ( !doneTransitioning&& fadeOutImage.color.a > 0 && fadeOutImage != null)
            {
               
          
                fadeImageColor.a = Mathf.MoveTowards(fadeOutImage.color.a, 0, Time.deltaTime * fadeSpeed);
                fadeOutImage.color = fadeImageColor;
                
            }
            else
            {

                doneTransitioning = true ;
           
                
            }
        }
        public void LoadScene(int buildIndex)
        {


            if (doneTransitioning)
            {
                doneTransitioning = false;
                fadeOutImage.enabled = false;

                if (SceneManager.GetActiveScene().buildIndex != buildIndex)
                {
                    GameStateManager.Instance.Play();
                   
                    SceneManager.LoadScene(buildIndex);

                }
               








            }
            else
            {
                fadeOutImage.enabled = true;
                fadeImageColor.a = 1.0f;
                fadeOutImage.color = fadeImageColor;
            }

        }

     
    }
}