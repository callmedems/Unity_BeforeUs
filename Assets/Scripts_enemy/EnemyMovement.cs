using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float velocidad = 2f;
    public Transform puntoIzquierdo;
    public Transform puntoDerecho;

    private bool yendoDerecha = true;
    void Start()
    {
        if (transform.position.x >= puntoDerecho.position.x)
            yendoDerecha = false;
        else if (transform.position.x <= puntoIzquierdo.position.x)
            yendoDerecha = true;
    }

    void Update()
    {
        Debug.Log("Posición actual: " + transform.position.x);
        Debug.Log("PuntoIzquierdo: " + puntoIzquierdo.position.x + " - PuntoDerecho: " + puntoDerecho.position.x);

        if (yendoDerecha)
        {
            transform.Translate(Vector2.right * velocidad * Time.deltaTime);
            if (transform.position.x >= puntoDerecho.position.x)
            {
                Debug.Log("↩ Cambiando a izquierda");
                yendoDerecha = false;
            }
        }
        else
        {
            transform.Translate(Vector2.left * velocidad * Time.deltaTime);
            if (transform.position.x <= puntoIzquierdo.position.x)
            {
                Debug.Log("➡ Cambiando a derecha");
                yendoDerecha = true;
            }
        }
    }
}
