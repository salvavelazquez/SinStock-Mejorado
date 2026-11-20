
using UnityEngine;
using UnityEngine.EventSystems;

public class MobileSwipeController : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private MovimientoPlayer player;

    [SerializeField] private TutorialManager tutorialManager;

    [Header("Sensibilidad")]
    [SerializeField] private float distanciaMinima = 35f;

    private Vector2 inicioToque;
    private int dedoActivo = -1;
    private bool gestoEjecutado = false;

    private void Update()
    {
        foreach (Touch toque in Input.touches)
        {
            if (toque.phase == TouchPhase.Began &&
                dedoActivo == -1)
            {
                if (EventSystem.current != null &&
                    EventSystem.current.IsPointerOverGameObject(
                        toque.fingerId))
                    continue;

                dedoActivo = toque.fingerId;
                inicioToque = toque.position;
                gestoEjecutado = false;
            }

            if (toque.fingerId != dedoActivo)
                continue;

            if (toque.phase == TouchPhase.Moved &&
                !gestoEjecutado)
            {
                DetectarGesto(toque.position);
            }

            if (toque.phase == TouchPhase.Ended ||
                toque.phase == TouchPhase.Canceled)
            {
                dedoActivo = -1;
                gestoEjecutado = false;
            }
        }
    }


    private void DetectarGesto(Vector2 posicionActual)
    {
        Vector2 diferencia = posicionActual - inicioToque;

        if (diferencia.magnitude < distanciaMinima)
            return;

        Vector2 direccion;

        if (Mathf.Abs(diferencia.x) >
            Mathf.Abs(diferencia.y))
        {
            if (diferencia.x > 0)
            {
                player.MoverDerecha();
                direccion = Vector2.right;
            }
            else
            {
                player.MoverIzquierda();
                direccion = Vector2.left;
            }
        }
        else if (diferencia.y > 0)
        {
            player.Salto();
            direccion = Vector2.up;
        }
        else
        {
            // Ignorar deslizamientos hacia abajo.
            gestoEjecutado = true;
            return;
        }

        gestoEjecutado = true;

        if (tutorialManager != null)
        {
            tutorialManager.RegistrarGesto(direccion);
        }
    }

}
