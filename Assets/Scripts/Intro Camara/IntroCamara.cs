using UnityEngine;
using System.Collections;

public class IntroCamara : MonoBehaviour
{
    [SerializeField] private MovimientoPlayer jugador;

    public bool IntroTerminada { get; private set; }
    public Transform camaraFrontalOsito;
    public Transform camaraFrontalGolem;
    public Transform camaraJuego;

    public float tiempoEspera = 2f;
    public float velocidadTransicion = 2f;

    private bool transicionActiva = false;

    void Start()
    {
        jugador.HabilitarControles(false);
        StartCoroutine(TransicionDesde(camaraFrontalOsito));
    }

    private void Awake()
    {
        if (camaraFrontalOsito != null)
        {
            transform.position = camaraFrontalOsito.position;
            transform.rotation = camaraFrontalOsito.rotation;
        }
    }

    public void MostrarGolem()
    {
        if (!transicionActiva)
            StartCoroutine(TransicionDesde(camaraFrontalGolem));
    }

    IEnumerator TransicionDesde(Transform origen)
    {
        transicionActiva = true;
        IntroTerminada = false;

        transform.position = origen.position;
        transform.rotation = origen.rotation;

        yield return new WaitForSeconds(tiempoEspera);

        float t = 0;

        Vector3 posInicial = transform.position;
        Quaternion rotInicial = transform.rotation;

        while (t < 1)
        {
            t += Time.deltaTime * velocidadTransicion;

            transform.position = Vector3.Lerp(
                posInicial,
                camaraJuego.position,
                t
            );

            transform.rotation = Quaternion.Lerp(
                rotInicial,
                camaraJuego.rotation,
                t
            );

            yield return null;
        }

        transicionActiva = false;
        IntroTerminada = true;
        jugador.HabilitarControles(true);
    }
}