using UnityEngine;

public class charactercontroller : MonoBehaviour
{
    public float Velocidad = 5f;
    public float FuerzaSalto = 10f;

    private Rigidbody2D rb;
    private bool enSuelo = false;

    public Transform detectorSuelo;
    public float radioDeteccion = 0.2f;
    public LayerMask capaSuelo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        procesarMovimiento();

        if (Input.GetButtonDown("Jump") && enSuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, FuerzaSalto);
        }

        // Detectar si está tocando el suelo
        enSuelo = Physics2D.OverlapCircle(detectorSuelo.position, radioDeteccion, capaSuelo);
    }

    void procesarMovimiento()
    {
        float InputMovimiento = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(InputMovimiento * Velocidad, rb.linearVelocity.y);
    }
}