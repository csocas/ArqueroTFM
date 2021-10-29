using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamecontroller : MonoBehaviour
{
    public bool turnojugador = true;
    public playercontroller controladorJugador;
    public Transform camara;
    public Vector3 offsetPlayer;
    public Vector3 offsetIa;
    public float vCamara = 2f;
    public float minimoAlturaCamara;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameObject.FindGameObjectWithTag("flecha") != null)
        {
            Transform flecha = GameObject.FindGameObjectWithTag("flecha").transform;
            Vector3 posicion = new Vector3(flecha.transform.position.x, flecha.transform.position.y, camara.transform.position.z);
            posicion.y = Mathf.Clamp(posicion.y, minimoAlturaCamara, 9999f);
            camara.transform.position = Vector3.Lerp(camara.transform.position,posicion, Time.deltaTime * vCamara);
            if (flecha.transform.position.y<-10f)
            {
                Destroy(flecha.gameObject);
            }
            
        }
        else if(turnojugador == true)
        {
            Vector3 posicion = new Vector3(controladorJugador.transform.position.x + offsetPlayer.x, controladorJugador.transform.position.y + offsetPlayer.y, camara.transform.position.z);
            camara.transform.position = Vector3.Lerp(camara.transform.position, posicion , Time.deltaTime * vCamara);
        }
        else
        {

        }
    }

    public void onPlayerFire()
    {
        turnojugador = false;
        controladorJugador.enabled = false;

    }
}
