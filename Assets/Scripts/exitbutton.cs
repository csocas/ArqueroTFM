using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class exitbutton : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(pressed);




































    }


    void pressed ()
    {
        Application.Quit();
    }
}
