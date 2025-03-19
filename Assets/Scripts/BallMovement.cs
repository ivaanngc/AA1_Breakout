using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 4f;

    public GameManager gameManager;

    public Rigidbody2D rb;

    private bool formPowerUp = false;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        if (!formPowerUp)
        {
            Vector2 randomDir = new Vector2(Random.Range(-0.8f, 0.8f), Random.Range(-0.8f, 0.8f));
            rb.velocity = randomDir.normalized * speed;
        }
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
        else if (collision.CompareTag("Muerte"))
        {
            gameManager.BolaPerdida();
            Destroy(gameObject);
        }
    }

    public void OverrideDirecction(Vector2 dir)
    {
        rb.velocity = dir.normalized * speed;
        formPowerUp = true;
    }
}
