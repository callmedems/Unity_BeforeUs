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

        if (yendoDerecha)
        {
            transform.Translate(Vector2.right * velocidad * Time.deltaTime);
            if (transform.position.x >= puntoDerecho.position.x)
            {
                yendoDerecha = false;
            }
        }
        else
        {
            transform.Translate(Vector2.left * velocidad * Time.deltaTime);
            if (transform.position.x <= puntoIzquierdo.position.x)
            {
                yendoDerecha = true;
            }
        }
    }
}