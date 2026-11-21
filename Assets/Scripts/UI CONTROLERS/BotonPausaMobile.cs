
using UnityEngine;

public class BotonPausaMobile : MonoBehaviour
{
    public void PausarJuego()
    {
        if (CambioEntreEscenas.Instance != null)
        {
            CambioEntreEscenas.Instance.AlternarPausa();
        }
        else
        {
            Debug.LogWarning(
                "No se encontro CambioEntreEscenas"
            );
        }
    }
}
