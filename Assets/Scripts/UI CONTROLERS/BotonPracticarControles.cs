
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonPracticarControles : MonoBehaviour
{
    [Header("Escena")]
    [SerializeField] private string nombreEscenaJuego;

    [Header("Interfaz")]
    [SerializeField] private GameObject panelComoJugar;

    public void PracticarControles()
    {
        // Ocultar la interfaz de instrucciones.
        if (panelComoJugar != null)
            panelComoJugar.SetActive(false);

        // Solicitar el tutorial interactivo.
        SolicitudTutorial.repetirTutorial = true;

        // Cargar la escena del juego.
        SceneManager.LoadScene(
            nombreEscenaJuego,
            LoadSceneMode.Single
        );
    }
}
