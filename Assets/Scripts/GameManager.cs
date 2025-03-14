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
}
