using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemigo dañó al jugador");
            collision.gameObject.GetComponent<PlayerHealth>()?.TakeDamage(1);
        }
    }
}
