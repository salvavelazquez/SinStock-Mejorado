
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesDeVictoriayDerrota : MonoBehaviour
{
    public void VolverAlMenuPrincipal()
    {
        Debug.Log("Volviendo al menu principal");

        // Restaurar el tiempo del juego.
        Time.timeScale = 1f;

        // Si existe el administrador, utilizarlo.
        if (CambioEntreEscenas.Instance != null)
        {
            CambioEntreEscenas.Instance.VolverAlMenuPrincipal();
        }
        else
        {
            // Si no existe, cargar directamente el menu.
            SceneManager.LoadScene(0);
        }
    }
}
