using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class archercontroller : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    public float fuerzaSalto;
    public bool enPiso;
    public Transform refPie;
    float movX;
    public float velX;




    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxis("Horizontal");
        anim.SetFloat("absMovX", Mathf.Abs(movX));
        rb.velocity = new Vector2(velX * movX, rb.velocity.y);


        enPiso = Physics2D.OverlapCircle(refPie.position, 1f, 1<<10);
        anim.SetBool("enPiso", enPiso);


        if (Input.GetButtonDown("Jump") && enPiso)
        {
            rb.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);

        }

        if (movX < 0) transform.localScale = new Vector3(-1, 1, 1);
        if (movX > 0) transform.localScale = new Vector3(1, 1, 1);


        


    }


    private void FixedUpdate()
    {

        Vector3 dondeEstoy = Camera.main.transform.position;
        Vector3 dondeQuieroIr = transform.position - new Vector3(0, 0, 20);

        Camera.main.transform.position = Vector3.Lerp(dondeEstoy, dondeQuieroIr, .05f);

    }
}
