using UnityEngine;

public class SpawnObstaculos : MonoBehaviour
{
    [Header("Control del tutorial")]
    [SerializeField] private bool puedeGenerar = true;
    [SerializeField] private GameObject[] obstaculos; // Array de prefabs de obstáculos
    [SerializeField] private GameObject[] obstaculosGrandes; // Array de prefabs de obstáculos grandes
    [SerializeField] private float spawnInterval = 1.5f; // Intervalo de tiempo entre cada spawn
    [SerializeField] private float nextSpawnTime = 0f; // Tiempo para el próximo spawn
    [SerializeField] private Transform[] transformPosiciones; // Array de posiciones donde se pueden spawnear los obstáculos
    private bool lanzoObjetoGrande; // Variable para controlar si se ha lanzado un objeto grande
    private int contadorObstaculos; // Contador para controlar el número de obstáculos lanzados
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        // Durante el tutorial no generamos obstáculos.
        if (!puedeGenerar)
            return;

        nextSpawnTime += Time.deltaTime;

        if (nextSpawnTime >= spawnInterval)
        {
            Spawn();
            nextSpawnTime = 0f;
            contadorObstaculos++;

            if (contadorObstaculos >= 5)
            {
                lanzoObjetoGrande = false;
                contadorObstaculos = 0;
            }
        }
    }


    public void PausarGeneracion()
    {
        puedeGenerar = false;
        nextSpawnTime = 0f;
    }

    public void ReanudarGeneracion()
    {
        nextSpawnTime = 0f;
        puedeGenerar = true;
    }



    public void Spawn()
    {
        int randomIndex = Random.Range(0, obstaculos.Length); // Selecciona un índice aleatorio para el prefab de obstáculo
        int randomIndexGrande = Random.Range(0, obstaculosGrandes.Length); // Selecciona un índice aleatorio para el prefab de obstáculo grande
        int randomPositionIndex = Random.Range(0, transformPosiciones.Length); // Selecciona un índice aleatorio para la posición de spawn
        if ( (randomIndexGrande==0|| randomIndexGrande==1)&& !lanzoObjetoGrande)
        {
            Instantiate(obstaculosGrandes[randomIndexGrande], transform.position, Quaternion.identity);
            lanzoObjetoGrande = true; // Marca que se ha lanzado un objeto grande
        } else
        {
            Instantiate(obstaculos[randomIndex], transformPosiciones[randomPositionIndex].position, Quaternion.identity);
        }
    }
}
