using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform objetivo; // El personaje
    public Vector3 offset;     // Para que no esté centrado exactamente si quieres

    void LateUpdate()
    {
        if (objetivo != null)
        {
            transform.position = new Vector3(
                objetivo.position.x + offset.x,
                objetivo.position.y + offset.y,
                transform.position.z  // Mantén la Z de la cámara
            );
        }
    }
}

