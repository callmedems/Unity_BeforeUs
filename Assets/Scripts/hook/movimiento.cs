using UnityEngine; //utiliza librerías



public class movimiento : MonoBehaviour{
    public float speed=5f; //habilita la velocidad, f es para flotante
    public float jumpForce = 10f; //fuerza con la que va a saltar
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool isGrounded; //verifica si el personaje está tocando el suelo o no

    void Start(){
        rb = GetComponent<Rigidbody2D>(); //genero un componente de rigid body a mi variable
    }

    // Update is called once per frame
    void Update(){
        moveInput.x = Input.GetAxis("Horizontal");
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
            Jump();
        }
    }

    void Jump(){
        if(isGrounded){
            rb.linearVelocity = new Vector2(rb.linearVelocity.x,jumpForce);
            isGrounded = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("suelo")){
            isGrounded= true;
        }
    }

    void FixedUpdate(){
        rb.linearVelocity = new Vector2(moveInput.x * speed,rb.linearVelocity.y);
    }
}
