
using System.Collections;
using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{

    [Header("Inicio de partida")]
    [SerializeField] private IntroCamara introCamara;
    [SerializeField] private float esperaDespuesCamara = 2f;

    [Header("Animacion del tutorial")]
    [SerializeField] private Animator animadorMano;
    [SerializeField] private GameObject imagenGesto;

    [Header("Finalizacion de practica")]
    [SerializeField] private GameObject panelFinPractica;
    [SerializeField] private string nombreEscenaMenu;

    private bool esPracticaVoluntaria = false;

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

        // Guardamos si el jugador entro desde Practicar controles.
        esPracticaVoluntaria = SolicitudTutorial.repetirTutorial;

        // Limpiamos la solicitud para futuras partidas.
        SolicitudTutorial.repetirTutorial = false;

        if (panelFinPractica != null)
            panelFinPractica.SetActive(false);

        if (completado && !esPracticaVoluntaria)
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

        if (imagenGesto != null)
            imagenGesto.SetActive(false);

        yield return new WaitForSeconds(esperaFinal);

        // Guardamos que el tutorial ya fue completado.
        PlayerPrefs.SetInt(CLAVE_TUTORIAL, 1);
        PlayerPrefs.Save();

        panelTutorial.SetActive(false);

        if (esPracticaVoluntaria)
        {
            // No comienza la partida.
            // Mostramos las opciones de finalizacion.
            if (panelFinPractica != null)
                panelFinPractica.SetActive(true);
        }
        else
        {
            // Primera vez: comienza la partida normalmente.
            IniciarJuego();
        }
    }




    private void IniciarJuego()
    {
        StartCoroutine(EsperarCamaraEIniciar());
    }

    private IEnumerator EsperarCamaraEIniciar()
    {
        // Esperar a que termine la presentacion de Fulbito.
        if (introCamara != null)
        {
            yield return new WaitUntil(
                () => introCamara.IntroTerminada
            );
        }

        // Dar tiempo para que el jugador se prepare.
        yield return new WaitForSeconds(esperaDespuesCamara);

        // Comenzar a generar obstaculos.
        if (spawnerObstaculos != null)
            spawnerObstaculos.ReanudarGeneracion();

        // Comenzar a generar alfajores.
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


    public void JugarAhora()
    {
        esPracticaVoluntaria = false;

        if (panelFinPractica != null)
            panelFinPractica.SetActive(false);

        IniciarJuego();
    }


    public void VolverAlMenu()
    {
        SolicitudTutorial.repetirTutorial = false;

        CambioEntreEscenas.Instance.VolverAlMenuPrincipal();
    }


}
