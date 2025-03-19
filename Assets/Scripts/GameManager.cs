using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI textoPuntuacion;
    public TextMeshProUGUI textoVidas;
    public int vidas = 3;
    public int puntuacion = 0;

    public Transform PlayerPos;
    public Transform SpawnPos;
    public GameObject ballPrefab;

    private int bolasPantalla = 1;

    public void SumarPuntos(int cantidad)
    {
        puntuacion += cantidad;
        textoPuntuacion.text = puntuacion.ToString();
    }
    public void SumarVidas(int cantidad)
    { 
        vidas += cantidad;
        textoVidas.text = vidas.ToString();
    }
    public void BolaPerdida()
    {
        vidas -= 1;
        bolasPantalla -= 1;
        if (SinVidas())
        {
            Debug.Log("Moriste");
        }
        else if(bolasPantalla <= 0)
        { 
            RespawnBall();
        }
        vidas = Mathf.Max(vidas, 0);
        textoVidas.text = vidas.ToString();
    }

    private bool SinVidas()
    {
        return vidas < 0;
    }

    void RespawnBall()
    {
        Instantiate(ballPrefab, SpawnPos.position, Quaternion.identity);
        bolasPantalla += 1;
    }

    public void PowerUpRojo()
    {
        Instantiate(ballPrefab, SpawnPos.position, Quaternion.identity);
        vidas += 1;
        bolasPantalla += 1;
        textoVidas.text = vidas.ToString();
    }

    public void PowerUpVerde()
    {
        //spawn y direccion bola 1
        Vector3 spawPos = PlayerPos.position + new Vector3 (-0.3f, 1.5f);
        GameObject ball = Instantiate(ballPrefab, spawPos, Quaternion.identity);
        Vector2 dir = -(Vector2)PlayerPos.right + (Vector2)PlayerPos.up;
        ball.GetComponent<BallMovement>().OverrideDirecction(dir.normalized);

        //spawn y direccion bola 2
        spawPos = PlayerPos.position + new Vector3(0f, 1.5f);
        ball = Instantiate(ballPrefab, spawPos, Quaternion.identity);
        dir = PlayerPos.up;
        ball.GetComponent<BallMovement>().OverrideDirecction(dir.normalized);

        //spawn y direccion bola 3
        spawPos = PlayerPos.position + new Vector3(0.3f, 1.5f);
        ball = Instantiate(ballPrefab, spawPos, Quaternion.identity);
        dir = PlayerPos.right + PlayerPos.up;
        ball.GetComponent<BallMovement>().OverrideDirecction(dir.normalized);

        vidas += 3;
        bolasPantalla += 3;
        textoVidas.text = vidas.ToString();
    }

    public void PowerUpAzul()
    {
        BallMovement[] balls = FindObjectsOfType<BallMovement>();
        foreach (BallMovement item in balls)
        {
            Instantiate(ballPrefab, item.gameObject.transform.position, Quaternion.identity);
            vidas += 1;
            bolasPantalla += 1;
            textoVidas.text = vidas.ToString();
        }
    }
}
