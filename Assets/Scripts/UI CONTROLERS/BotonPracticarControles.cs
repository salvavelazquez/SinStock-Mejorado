
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonPracticarControles : MonoBehaviour
{
    [SerializeField] private string nombreEscenaJuego;

    public void PracticarControles()
    {
        SolicitudTutorial.repetirTutorial = true;

        SceneManager.LoadScene(nombreEscenaJuego);
    }
}
