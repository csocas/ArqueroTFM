using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevelTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(PlayerPrefs.GetInt("level") <= int.Parse(SceneManager.GetActiveScene().name))
        {
            PlayerPrefs.SetInt("level", int.Parse(SceneManager.GetActiveScene().name) + 1);
            SceneManager.LoadScene(PlayerPrefs.GetInt("level").ToString());
        }
        else
        {
            SceneManager.LoadScene((PlayerPrefs.GetInt("level") +1).ToString());
        }
        
    }

}
