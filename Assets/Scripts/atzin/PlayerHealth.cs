using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int vida = 3;
    public float tiempoInvulnerable = 1.5f;
    private float tiempoUltimoDaño = -999f;

    public void TakeDamage(int cantidad)
    {
        if (Time.time - tiempoUltimoDaño < tiempoInvulnerable)
            return; 

        vida -= cantidad;
        tiempoUltimoDaño = Time.time;

        Debug.Log("¡Te golpearon! Vida restante: " + vida);

        if (vida <= 0)
        {
            Debug.Log("Has perdido todas las vidas.");
        }
    }
}