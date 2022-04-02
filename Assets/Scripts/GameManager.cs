using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject slender;
    [SerializeField] Transform[] arrayPuntosSalida;
    [SerializeField] GameObject panelFinal;
    [SerializeField] GameObject Mensaje_Ganar;

    public Text puntuacion;
    private int puntoSalida;

    public AudioSource MusicaSuspenso;
    public AudioSource MusicaSuspenso2;
    public AudioSource Pasos;
    public AudioSource SonidoAmbiente;
    public int cont;
  

    private void Start()
    {
        SonidoAmbiente.Play();
        panelFinal.SetActive(false);
        Mensaje_Ganar.SetActive(false);
    }

    private void EstablecerPunto(GameObject objeto)
    {
        puntoSalida = Random.Range(0, arrayPuntosSalida.Length);
        objeto.transform.position = arrayPuntosSalida[puntoSalida].position;
    }


    public void CrearNuevoSlender()
    {
        Instantiate(slender);
        EstablecerPunto(slender);
    }

    public void PuntualizarMarcador(int contador)
    {
        cont = contador;
        puntuacion.text = "Puntuacion: " + contador;

        switch (contador)
        {
            case 1:
                Pasos.Play();
                
                break;
            case 2:
                MusicaSuspenso2.Play();
                break;
            case 3:
                
                break;
            case 4:
                MusicaSuspenso.Play();
                break;
            case 5:
                break;
        }
    }


    public void Aparecefinal()
    {
        Cursor.lockState = CursorLockMode.None;
        panelFinal.SetActive(true);
    }

    public void Ganar()
    {
        Cursor.lockState = CursorLockMode.None;
        Mensaje_Ganar.SetActive(true);
        Destroy(slender);
        SonidoAmbiente.Stop();
        MusicaSuspenso.Stop();
        Pasos.Stop();
    }

    

}