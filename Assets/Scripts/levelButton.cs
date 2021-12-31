using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelButton : MonoBehaviour
{

    bool canLoad = false;
    public GameObject candado;

    private void Awake()
    {

        GetComponent<Button>().onClick.AddListener(pressed);

        if(PlayerPrefs.GetInt("level") == 0)
        {
            PlayerPrefs.SetInt("level", 1);
        }

        int level = int.Parse(gameObject.name);

        if (PlayerPrefs.GetInt("level") >= level)
        {
            canLoad = true;
            candado.SetActive(false);
        }
    }

    public void pressed ()
    {
        if (canLoad)
        {
            SceneManager.LoadScene(gameObject.name);
        }
    }

    
}
