using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoBloque : MonoBehaviour
{
    public int Puntuacion = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bola"))
        { 
            //sumar puntos

            Destroy(gameObject);
        }
    }
}
