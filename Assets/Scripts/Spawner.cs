using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnernew : MonoBehaviour
{
    public GameObject objectPrefab; // Prefab del objeto a generar
    public GameObject targetCar;   // El carrito que el spawner seguirá
    public Vector3 offset = new Vector3(0, 10, 20); // Offset relativo al carrito
    public float spawnInterval = 1f; // Tiempo entre generaciones

    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    void Update()
    {
        // Actualizar la posición del spawner para que esté 20 metros adelante del carrito
        if (targetCar != null)
        {
            transform.position = targetCar.transform.position + targetCar.transform.forward * offset.z +
                                 Vector3.up * offset.y + targetCar.transform.right * offset.x;
        }
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            // Generar un objeto en la posición del spawner
            Instantiate(objectPrefab, transform.position, Quaternion.identity);

            // Esperar antes de generar otro objeto
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}