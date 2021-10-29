using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flechaCollider : MonoBehaviour
{
    public Object[] toDestroy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "map" || collision.gameObject.tag == "enemy")
        {
            transform.SetParent(collision.gameObject.transform);
            for (int i = 0; i < toDestroy.Length; i++)
            {
                Destroy(toDestroy[i]);
            }
        }
    }
}
