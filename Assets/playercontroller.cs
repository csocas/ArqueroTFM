using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playercontroller : MonoBehaviour

{
    public Transform pivote;
    public AnimationCurve curve;
    public float vida = 100f;
    public GameObject potenciaObject;
    public Image potenciaImage;
    public GameObject flechaPrefab;


    public Transform posicionInicialFlecha;
    public float potenciaMaximaflecha=500f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    float timer;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            timer = 0f;
            potenciaObject.SetActive(true);

        }

        if (Input.GetMouseButton(0))
        {
            potenciaObject.transform.position = Input.mousePosition;
            timer += Time.deltaTime;
            if(timer >= 2f)
            {
                timer = 0f;
            }

            float multiplicadorPotencia = curve.Evaluate(timer);
            potenciaImage.rectTransform.sizeDelta = new Vector2(multiplicadorPotencia * 80.316f, 17.843f);

        }

        if (Input.GetMouseButtonUp(0))
        {
            GameObject flecha = Instantiate(flechaPrefab, posicionInicialFlecha.position, posicionInicialFlecha.rotation);
            Rigidbody rb = flecha.GetComponent<Rigidbody>();
            rb.AddForce(flecha.transform.forward * potenciaMaximaflecha * curve.Evaluate(timer));
        
            potenciaObject.SetActive(false);

        }
    }

    private void FixedUpdate()
    {
        var lookAtPos = Input.mousePosition;
        lookAtPos.z = pivote.transform.position.z - Camera.main.transform.position.z;
        lookAtPos = Camera.main.ScreenToWorldPoint(lookAtPos);
        pivote.transform.LookAt(lookAtPos);

        
    }

}

