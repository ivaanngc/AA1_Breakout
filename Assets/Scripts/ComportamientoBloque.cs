using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoBloque : MonoBehaviour
{
    public int Puntuacion = 1;
    public GameObject[] powerUpsPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bola"))
        {
            int random = Random.Range(1, 10);
            if (random <= 1)
            {
                int randElementIndex = Random.Range(0, powerUpsPrefab.Length);
                Instantiate(powerUpsPrefab[randElementIndex], transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}
