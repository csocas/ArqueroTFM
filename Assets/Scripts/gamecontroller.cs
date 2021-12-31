using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class gamecontroller : MonoBehaviour
{
    public static gamecontroller singleton;
    public bool turnojugador = true;
    public playercontroller controladorJugador;
    public iacontroller controladoria;
    public Transform camara;
    public Vector3 offsetPlayer;
    public Vector3 offsetIa;
    public float vCamara = 2f;
    public float minimoAlturaCamara;
    public float playerHealth = 100f;
    public float iaHealth = 100f;

    public Image playerHealthUI;
    public Image iaHealthUI;

    public GameObject GameOver;
    public GameObject WinScreen;







    private void Awake()
    {
        singleton = this;

    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        if (GameObject.FindGameObjectWithTag("flecha") != null)
        {
            Transform flecha = GameObject.FindGameObjectWithTag("flecha").transform;
            Vector3 posicion = new Vector3(flecha.transform.position.x, flecha.transform.position.y, camara.transform.position.z);
            posicion.y = Mathf.Clamp(posicion.y, minimoAlturaCamara, 9999f);
            camara.transform.position = Vector3.Lerp(camara.transform.position, posicion, Time.deltaTime * vCamara);
            if (flecha.transform.position.y < -10f)
            {
                Destroy(flecha.gameObject);
            }

        }
        else if (turnojugador == true)
        {
            Vector3 posicion = new Vector3(controladorJugador.transform.position.x + offsetPlayer.x, controladorJugador.transform.position.y + offsetPlayer.y, camara.transform.position.z);
            camara.transform.position = Vector3.Lerp(camara.transform.position, posicion, Time.deltaTime * vCamara);
        }
        else
        {
            Vector3 posicion = new Vector3(controladoria.transform.position.x + offsetIa.x, controladoria.transform.position.y + offsetIa.y, camara.transform.position.z);
            camara.transform.position = Vector3.Lerp(camara.transform.position, posicion, Time.deltaTime * vCamara);
        }

        
    }

    public void OnFire()
    {
        StartCoroutine(detectTurn());
    }

    IEnumerator detectTurn()
    {
        controladorJugador.enabled = false;
        controladoria.enabled = false;
        yield return new WaitUntil(() => GameObject.FindGameObjectWithTag("flecha") == null);

        if (turnojugador)
        {
            SetIaTurn();

        }
        else
        {
            SetPlayerTurn();

        }
    }

    public void SetIaTurn()
    {
        turnojugador = false;
        controladorJugador.enabled = false;
        controladoria.enabled = true;


    }

    public void SetPlayerTurn()
    {
        turnojugador = true;
        controladorJugador.enabled = true;
        controladoria.enabled = false;

    }

    public void OnHit()
    {
        if (turnojugador)
        {
            iaHealth -= 34f;

        }
        else
        {
            playerHealth -= 34f;

        }

        if(playerHealth <= 0f)
        {
            GameOver.SetActive(true);

        }


        if (iaHealth <= 0f)
        {
            WinScreen.SetActive(true);

        }
        UpdateUI();



    }

    public void UpdateUI()
    {
        playerHealthUI.rectTransform.sizeDelta = new Vector2(playerHealth * 339.9921f / 100f, playerHealthUI.rectTransform.sizeDelta.y);
        iaHealthUI.rectTransform.sizeDelta = new Vector2(iaHealth * 339.9921f / 100f, iaHealthUI.rectTransform.sizeDelta.y);
    }

}
