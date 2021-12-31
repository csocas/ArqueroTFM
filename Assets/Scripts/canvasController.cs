using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class canvasController : MonoBehaviour
{

   public void MainMenu ()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void nextLevel()
    {
        if (PlayerPrefs.GetInt("level") <= int.Parse(SceneManager.GetActiveScene().name))
        {
            PlayerPrefs.SetInt("level", int.Parse(SceneManager.GetActiveScene().name) + 1);
            SceneManager.LoadScene(PlayerPrefs.GetInt("level").ToString());
        }
        else
        {
            SceneManager.LoadScene((PlayerPrefs.GetInt("level") + 1).ToString());
        }
    }
}
