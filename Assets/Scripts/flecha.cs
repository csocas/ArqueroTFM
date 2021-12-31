using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flecha : MonoBehaviour
{
    Rigidbody rb;
    public float multiplicador;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }


    private void FixedUpdate()
    {
        // rb.AddTorque((rb.velocity.normalized.y * rb.velocity.normalized.x) * multiplicador,ForceMode2D.Force);

        //Quaternion toRotation = Quaternion.LookRotation(Vector2.right, rb.velocity);
        //transform.rotation = toRotation;

        //Debug.DrawRay(transform.position, rb.velocity.normalized, Color.red);
        //transform.rotation = Quaternion.LookRotation(transform.up, rb.velocity.normalized);

        //transform.rotation = Quaternion.Euler(new Vector3(0f, 0f,Vector3.Angle((Vector2)transform.position + rb.velocity.normalized, transform.position)));

        Debug.DrawLine(transform.position, transform.position+ rb.velocity.normalized);

        transform.LookAt(transform.position + rb.velocity.normalized);

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
