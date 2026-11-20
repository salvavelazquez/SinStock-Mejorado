
using System.Collections;
using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    [Header("Animacion del tutorial")]
    [SerializeField] private Animator animadorMano;
    [SerializeField] private GameObject imagenGesto;

    [Header("Interfaz")]
    [SerializeField] private GameObject panelTutorial;
    [SerializeField] private TMP_Text textoInstruccion;

    [Header("Generadores")]
    [SerializeField] private SpawnObstaculos spawnerObstaculos;
    [SerializeField] private SpawnerAlfajores spawnerAlfajores;

    [Header("Configuracion")]
    [SerializeField] private float esperaFinal = 2f;

    private const string CLAVE_TUTORIAL =
        "TutorialMobileCompletado";

    private int pasoActual = 0;
    private bool tutorialActivo = false;

    private void Awake()
    {
        // Evitar que los generadores comiencen
        // antes de comprobar el tutorial.
        if (spawnerObstaculos != null)
            spawnerObstaculos.PausarGeneracion();

        if (spawnerAlfajores != null)
            spawnerAlfajores.PausarGeneracion();
    }


    private void Start()
    {
        bool completado =
            PlayerPrefs.GetInt(CLAVE_TUTORIAL, 0) == 1;

        bool repetir = SolicitudTutorial.repetirTutorial;

        // Consumimos la solicitud para que no se repita
        // al reiniciar la escena.
        SolicitudTutorial.repetirTutorial = false;

        if (completado && !repetir)
        {
            panelTutorial.SetActive(false);

            if (imagenGesto != null)
                imagenGesto.SetActive(false);

            IniciarJuego();
        }
        else
        {
            RepetirTutorial();
        }
    }



    private void MostrarInstruccion()
    {
        switch (pasoActual)
        {
            case 0:
                textoInstruccion.text =
                    "Desliza hacia la izquierda";

                ReproducirAnimacion("SwipeIzquierda");
                break;

            case 1:
                textoInstruccion.text =
                    "Desliza hacia la derecha";

                ReproducirAnimacion("SwipeDerecha");
                break;

            case 2:
                textoInstruccion.text =
                    "Desliza hacia arriba para saltar";

                ReproducirAnimacion("SwipeArriba");
                break;

            default:
                StartCoroutine(FinalizarTutorial());
                break;
        }
    }


    public void RegistrarGesto(Vector2 direccion)
    {
        if (!tutorialActivo)
            return;

        bool correcto = false;

        switch (pasoActual)
        {
            case 0:
                correcto = direccion == Vector2.left;
                break;

            case 1:
                correcto = direccion == Vector2.right;
                break;

            case 2:
                correcto = direccion == Vector2.up;
                break;
        }

        if (correcto)
        {
            pasoActual++;
            MostrarInstruccion();
        }
    }

    public void RepetirTutorial()
    {
        StopAllCoroutines();

        if (spawnerObstaculos != null)
            spawnerObstaculos.PausarGeneracion();

        if (spawnerAlfajores != null)
            spawnerAlfajores.PausarGeneracion();

        pasoActual = 0;
        tutorialActivo = true;

        panelTutorial.SetActive(true);

        if (imagenGesto != null)
            imagenGesto.SetActive(true);

        MostrarInstruccion();
    }

    private void ReproducirAnimacion(string nombreAnimacion)
    {
        if (animadorMano == null)
            return;

        imagenGesto.SetActive(true);

        animadorMano.Play(nombreAnimacion, 0, 0f);
    }


    private IEnumerator FinalizarTutorial()
    {
        tutorialActivo = false;

        textoInstruccion.text = "¡Listo! ¡A correr!";

        // Ocultamos la mano al completar los gestos.
        if (imagenGesto != null)
            imagenGesto.SetActive(false);

        yield return new WaitForSeconds(esperaFinal);

        PlayerPrefs.SetInt(CLAVE_TUTORIAL, 1);
        PlayerPrefs.Save();

        panelTutorial.SetActive(false);
        IniciarJuego();
    }


    private void IniciarJuego()
    {
        if (spawnerObstaculos != null)
            spawnerObstaculos.ReanudarGeneracion();

        if (spawnerAlfajores != null)
            spawnerAlfajores.ReanudarGeneracion();
    }

    [ContextMenu("Reiniciar progreso del tutorial")]
    public void ReiniciarProgresoTutorial()
    {
        PlayerPrefs.DeleteKey("TutorialMobileCompletado");
        PlayerPrefs.Save();

        Debug.Log("Progreso del tutorial reiniciado");
    }
}
