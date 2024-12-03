using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Target; // El objeto al que la cámara seguirá
    public Vector3 offset = new Vector3(0, 5, -10); // Offset inicial de la cámara
    public float smoothSpeed = 0.125f; // Velocidad de suavizado para el movimiento de la cámara

    public float rotationSpeed = 100f; // Velocidad de rotación de la cámara
    private float currentYaw = 0f;     // Almacena el ángulo de rotación horizontal
    private float currentPitch = 0f;   // Almacena el ángulo de rotación vertical
    public float pitchLimit = 45f;     // Límite de inclinación de la cámara

    void LateUpdate()
    {
        // Manejar la entrada del usuario para rotar la cámara
        currentYaw += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        currentPitch -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        // Limitar la inclinación vertical de la cámara
        currentPitch = Mathf.Clamp(currentPitch, -pitchLimit, pitchLimit);

        // Calcular la posición deseada
        Vector3 desiredPosition = Target.transform.position + Quaternion.Euler(currentPitch, currentYaw, 0) * offset;

        // Suavizar el movimiento de la cámara
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Mirar hacia el objetivo
        transform.LookAt(Target.transform.position);
    }
}