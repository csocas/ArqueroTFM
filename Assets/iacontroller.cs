using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iacontroller : MonoBehaviour
{

    public GameObject flechaPrefab;
    public Transform posicionInicialFlecha;
    public float potenciaMaximaflecha;

    [Range(0f, 1f)]
    public float precisionMinima = 0f;
    [Range(0f, 1f)]
    public float precisionMaxima = 1f;




    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(waitToFire());

    }

    IEnumerator waitToFire()
    {
        yield return new WaitForSeconds(3f);
        Fire();

    }

    // Update is called once per frame
    void Fire()
    {

        GameObject flecha = Instantiate(flechaPrefab, posicionInicialFlecha.position, posicionInicialFlecha.rotation);
        Rigidbody rb = flecha.GetComponent<Rigidbody>();
        rb.AddForce(flecha.transform.forward * potenciaMaximaflecha * Random.Range(precisionMinima, precisionMaxima));

      
        gamecontroller.singleton.OnFire();


    }
}
