using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 20f; // Velocidad máxima de movimiento hacia adelante
    public float rotationSpeed = 100f; // Velocidad de rotación
    public float decelerationRate = 10f; // Tasa de desaceleración al presionar 'S'
    private float currentSpeed; // Velocidad actual del jugador

    void Start()
    {
        currentSpeed = moveSpeed; // Inicializar la velocidad actual con la velocidad máxima
    }

    void Update()
    {
        // Comprobar si 'S' está presionada para desacelerar
        if (Input.GetKey(KeyCode.S))
        {
            currentSpeed = Mathf.Max(0, currentSpeed - decelerationRate * Time.deltaTime);
        }
        else
        {
            // Si no se presiona 'S', la velocidad vuelve a la velocidad máxima
            currentSpeed = moveSpeed;
        }

        // Movimiento hacia adelante con la velocidad actual
        transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed);

        // Rotación hacia la izquierda mientras se presiona 'A'
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }

        // Rotación hacia la derecha mientras se presiona 'D'
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}

