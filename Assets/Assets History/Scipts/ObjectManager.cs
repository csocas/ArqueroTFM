using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectManager : MonoBehaviour
{

    private void Update()
    {
        AllObjectsCollected();
    }






    public void AllObjectsCollected()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("No quedan objetos, Victoria");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
