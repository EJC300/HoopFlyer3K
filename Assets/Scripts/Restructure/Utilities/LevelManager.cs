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

        public bool DoneTransitioning { get => doneTransitioning; set => doneTransitioning = value; }

        private void LateUpdate()
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
            if ( !DoneTransitioning&& fadeOutImage.color.a > 0 && fadeOutImage != null)
            {
                

                fadeImageColor.a = Mathf.MoveTowards(fadeOutImage.color.a, 0, Time.deltaTime * fadeSpeed);
              
                fadeOutImage.color = fadeImageColor;
              
            }
            if(fadeImageColor.a < 0.01f)
            {

                DoneTransitioning = true;
                fadeOutImage.enabled = false;

             
                
            }
          if(!fadeOutImage.enabled && DoneTransitioning)
            {
                fadeImageColor.a = 1.0f;
              
                fadeOutImage.color = fadeImageColor;
                return;
            }
        }
        public void LoadScene(int buildIndex)
        {


            if (DoneTransitioning)
            {
                DoneTransitioning = false;
                fadeOutImage.enabled = true;

                if (SceneManager.GetActiveScene().buildIndex != buildIndex)
                {
                    GameStateManager.Instance.Play();
                   
                    SceneManager.LoadScene(buildIndex);

                }
               








            }
           

        }

     
    }
}