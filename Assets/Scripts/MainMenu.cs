using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

  /*  public void QuitGame()
    {
        public IEnumerator QuitGame()
        {
            Debug.Log("Bye, have a good day!");
            //       SceneManager.LoadScene(SceneManaganer.GetActiveScene().Splashent)
            yield return new WaitForSeconds(5f);
            Application.Quit();
        }
    } */ 

    public void Credits()
    {

    }
}