using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    public AudioSource MusicaFondoMenuInicio;
    [SerializeField] private GameObject menuPrincipal;
    [SerializeField] private GameObject menuOpciones;
    public Slider slider;
    public float sliderValue;
    public Image imagenMute;

    public void Start()
    {
        Time.timeScale = 1f;
        MusicaFondoMenuInicio.Play();
        menuPrincipal.SetActive(true);
        menuOpciones.SetActive(false);
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
        RevisarSiEstoyMute();
    }

    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = slider.value;
        RevisarSiEstoyMute();
    }

    private void RevisarSiEstoyMute()
    {
        if (sliderValue == 0)
        {
            imagenMute.enabled = true;
        }
        else
        {
            imagenMute.enabled = false;
        }

    }

    public void IniciarJuego() {
        Time.timeScale = 1f;
        MusicaFondoMenuInicio.Stop();
        SceneManager.LoadScene("JuegoTerrorFinal");
    }

    public void Opciones()
    {
        menuPrincipal.SetActive(false);
        menuOpciones.SetActive(true);

    }

    public void Volver()
    {
        menuPrincipal.SetActive(true);
        menuOpciones.SetActive(false);
    }

    public void Salir()
    {
        MusicaFondoMenuInicio.Stop();
        Application.Quit();
    }
}
