using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flechaCollider : MonoBehaviour
{

    public Object[] toDestroy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "map" )
        {
            transform.SetParent(collision.gameObject.transform);
            Destruir();

            
        }else if ( collision.gameObject.tag == "enemy" || collision.gameObject.tag == "Player")
        {
            gamecontroller.singleton.OnHit();
            transform.SetParent(collision.gameObject.transform);
            Destruir();
        }
       
    }

    void Destruir()
    {
        for (int i = 0; i < toDestroy.Length; i++)
        {
            Destroy(toDestroy[i]);
        }
    }
}
