using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCollector : MonoBehaviour
{
    public GameObject targetCar;   // El carrito que el basurero seguirá
    public Vector3 offset = new Vector3(0, 0, -10); // Offset relativo al carrito
    public int collectedObjects = 0; // Contador de objetos recolectados

    void Update()
    {
        // Actualizar la posición del basurero para que siga al carrito con el offset deseado
        if (targetCar != null)
        {
            transform.position = targetCar.transform.position + targetCar.transform.forward * offset.z +
                                 Vector3.up * offset.y + targetCar.transform.right * offset.x;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto es recolectable
        if (other.CompareTag("Collectible"))
        {
            collectedObjects++; // Incrementar contador
            Destroy(other.gameObject); // Eliminar el objeto recolectado
            Debug.Log("Objetos recolectados: " + collectedObjects);
        }
    }
}
