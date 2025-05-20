using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{
    public GameObject proyectilPrefab;
    public Transform puntoDisparo;
    public float velocidad = 5f;
    public float tiempoEntreDisparos = 2f;

    private float tiempoUltimoDisparo;

    void Update()
    {
        if (Time.time - tiempoUltimoDisparo >= tiempoEntreDisparos)
        {
            Disparar();
            tiempoUltimoDisparo = Time.time;
        }
    }

    void Disparar()
    {
        GameObject bala = Instantiate(proyectilPrefab, puntoDisparo.position + transform.right * 1f, Quaternion.identity);
        bala.GetComponent<Rigidbody2D>().linearVelocity = Vector2.right * 5f; // fuerza hacia la derecha



        float direccion = Mathf.Sign(transform.localScale.x); // derecha = 1, izquierda = -1
        bala.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(direccion * velocidad, 0);

        Debug.Log("Disparo lanzado en dirección: " + direccion);
    }
}
