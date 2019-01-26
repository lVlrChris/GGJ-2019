using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// Handle interaction with the game menu.
public class MainMenu : MonoBehaviour
    {
        public void PlayGame()
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

 /*       public IEnumerator QuitGame()
            {
                 /// The name of the scene
                public string Splashpiel;

                /// Load the actual game scene.
                public void StartSplashpiel()
                     {
                         Application.LoadLevel(Splashpiel);
                     }
                Debug.Log("Bye, have a good day!");
                yield return new WaitForSeconds(5f);
                Application.Quit();
            }
 */   

        public void Credits()
            {

            }
    }