using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public int daño = 1;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colisión con: " + collision.name); // Solo imprime

    if (collision.CompareTag("Player"))
            {
                collision.GetComponent<PlayerHealth>()?.TakeDamage(daño);
                Destroy(gameObject);
            }
            else if (!collision.isTrigger && !collision.CompareTag("Enemy")) 
            {
                Destroy(gameObject);
            } 
    }

}
