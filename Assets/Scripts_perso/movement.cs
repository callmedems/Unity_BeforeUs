using UnityEngine;

public class Movement : MonoBehaviour {
    public float speed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool isGrounded;

    private Animator animator;        // Referencia al Animator
    private SpriteRenderer sprite;    // Para voltear el sprite

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update() {
        moveInput.x = Input.GetAxis("Horizontal");

        // Activar animación de caminar
        bool iswalking = Mathf.Abs(moveInput.x) > 0.1f;
        animator.SetBool("iswalking", iswalking);

        // Voltear sprite según la dirección
        if (moveInput.x > 0) {
            sprite.flipX = false;
        } else if (moveInput.x < 0) {
            sprite.flipX = true;
        }

        // Saltar
        if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }
    }

    void Jump() {
        if (isGrounded) {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("suelo")) {
            isGrounded = true;
        }
    }

    void FixedUpdate() {
        if (!GrappleActivo()) {
            rb.linearVelocity = new Vector2(moveInput.x * speed, rb.linearVelocity.y);
        }
    }

    bool GrappleActivo() {
        Grapple g = GetComponent<Grapple>();
        return g != null && g.isGrappling;
    }
}