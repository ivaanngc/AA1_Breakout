using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpAzul : MonoBehaviour
{
    GameManager gameManager;
    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pala"))
        {
            gameManager.PowerUpAzul();
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Muerte"))
        {
            Destroy(gameObject);
        }
    }
}
