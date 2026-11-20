using UnityEngine;

public class SpawnerAlfajores : MonoBehaviour
{
    [Header("Control del tutorial")]
    [SerializeField] private bool puedeGenerar = true;

    public GameObject alfajorPrefab;
    public GameObject[] alfajoresPoderosos;

    public float tiempoSpawn = 1f;
    public Transform[] puntosSpawn;

    public GameObject alfajorBlanco;
    public GameObject alfajorMarron;
    public GameObject alfajorRosado;

    private float temporizadorEspecial = 0f;
    public float intervaloEspecial = 5f;


    private void Start()
    {
        if (puedeGenerar)
        {
            IniciarGeneracionComun();
        }
    }

    private void IniciarGeneracionComun()
    {
        CancelInvoke(nameof(GenerarAlfajor));

        InvokeRepeating(
            nameof(GenerarAlfajor),
            1f,
            tiempoSpawn
        );
    }

    private void Update()
    {
        if (!puedeGenerar)
            return;

        temporizadorEspecial += Time.deltaTime;

        if (temporizadorEspecial >= intervaloEspecial)
        {
            temporizadorEspecial = 0f;
            VerificarEspeciales();
        }
    }

    void VerificarEspeciales()
    {
        int cantidad = GameManager.instancia.ObtenerCantidadAlfajores();

        if (cantidad >= 5 && GameManager.instancia.faseActual == 0)
        {
            SpawnearAlfajorBlanco();
        }
        else if (cantidad >= 15 && GameManager.instancia.faseActual == 1)
        {
            SpawnearAlfajorMarron();
        }
        else if (cantidad >= 20 && GameManager.instancia.faseActual == 2)
        {
            SpawnearAlfajorRosado();
        }
    }

    void GenerarAlfajor()
    {
        if (!puedeGenerar)
            return;

        int indice = Random.Range(0, puntosSpawn.Length);

        Instantiate(
            alfajorPrefab,
            puntosSpawn[indice].position,
            Quaternion.identity
        );
    }

    public void GenerarAlfajorPoderoso()
    {
        if (!puedeGenerar)
            return;

        int indice = Random.Range(0, alfajoresPoderosos.Length);
        int posicionIndice = Random.Range(0, puntosSpawn.Length);
        Instantiate(
            alfajoresPoderosos[indice],
            puntosSpawn[posicionIndice].position,
            Quaternion.identity
        );
    }

    public void SpawnearAlfajorBlanco()
    {
        SpawnEspecial(alfajorBlanco);
    }

    public void SpawnearAlfajorMarron()
    {
        SpawnEspecial(alfajorMarron);
    }

    public void SpawnearAlfajorRosado()
    {
        SpawnEspecial(alfajorRosado);
    }

    void SpawnEspecial(GameObject prefab)
    {
        if (!puedeGenerar)
            return;

        int posicionIndice =
            Random.Range(0, puntosSpawn.Length);

        Instantiate(
            prefab,
            puntosSpawn[posicionIndice].position,
            Quaternion.identity
        );
    }


    public void PausarGeneracion()
    {
        puedeGenerar = false;

        CancelInvoke(nameof(GenerarAlfajor));

        temporizadorEspecial = 0f;
    }

    public void ReanudarGeneracion()
    {
        if (puedeGenerar)
            return;

        puedeGenerar = true;
        temporizadorEspecial = 0f;

        IniciarGeneracionComun();
    }

}