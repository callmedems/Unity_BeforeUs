using UnityEngine;

public class charactercontroller : MonoBehaviour
{
    public float Velocidad;
    // Update is called once per frame
    void Update()
    {
        procesarMovimiento();
    }

    void procesarMovimiento()
    {

         //logica de momiviento

    float InputMovimiento = Input.GetAxis("Horizontal");
    Rigidbody2D rigidbody = GetComponent < Rigidbody2D >();

    rigidbody.linearVelocity = new Vector2(InputMovimiento* Velocidad, rigidbody.linearVelocity.y);

    }
   
    
    
}
