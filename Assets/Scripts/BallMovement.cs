using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 4f;

    public GameManager gameManager;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 randomDir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, -1f));
        rb.velocity = randomDir.normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Horizontal"))
        {
            Vector2 newVelocity = rb.velocity;
            newVelocity.x *= -1f;
            rb.velocity = newVelocity;
        }
        else if (collision.CompareTag("Vertical"))
        {
            Vector2 newVelocity = rb.velocity;
            newVelocity.y *= -1f;
            rb.velocity = newVelocity;
        }
        else if (collision.CompareTag("Pala"))
        {
            Vector2 newDirecction = transform.position - collision.transform.position;
            rb.velocity = newDirecction.normalized * speed;
        }
        else if (collision.CompareTag("Bloque"))
        {
            Vector2 newDirecction = transform.position - collision.transform.position;
            rb.velocity = newDirecction.normalized * speed;
            int puntuacionASumar = collision.GetComponent<ComportamientoBloque>().Puntuacion;
            gameManager.SumarPuntos(puntuacionASumar);
        }
    }
}
