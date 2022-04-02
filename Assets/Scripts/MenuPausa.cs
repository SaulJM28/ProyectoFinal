using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPausa : MonoBehaviour
{

    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private FirstPersonController FPS;

    [SerializeField] private GameObject menuOpciones;
    public Slider slider;
    public float sliderValue;
    public Image imagenMute;
  

    public void Start()
    {
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

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        FPS   = FindObjectOfType<FirstPersonController>();
        Cursor.lockState = CursorLockMode.Locked;
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           Pausa();
        }
    }

    public void Pausa()
    {
        Time.timeScale = 0f;
      //  botonPausa.SetActive(false);
        menuPausa.SetActive(true);
        gameManager.MusicaSuspenso.Pause();
        gameManager.SonidoAmbiente.Pause();
        gameManager.Pasos.Pause();
        //Pausar todos los sonidos al poner 
       // FPS.lockCursor = false;

        Cursor.lockState = CursorLockMode.None;
       
    }

    public void Reaunidar()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
       // botonPausa.SetActive(true);
        menuPausa.SetActive(false);
        //reproducir 
        gameManager.SonidoAmbiente.Play();

        switch (gameManager.cont)
        {
            case 1:
                gameManager.Pasos.Play()
                break;
            case 2:
                gameManager.MusicaSuspenso2.Play();
                break;
            case 3:

                break;
            case 4:
                gameManager.MusicaSuspenso.Play();
                break;
            case 5:
                break;
        }


    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Cerrar()
    {
        //Debug.Log("Cerrar juego");
        SceneManager.LoadScene("MainMenu");
    }


    public void Opciones()
    {
        menuPausa.SetActive(false);
        menuOpciones.SetActive(true);

    }

    public void Volver()
    {
        menuPausa.SetActive(true);
        menuOpciones.SetActive(false);
    }

}
