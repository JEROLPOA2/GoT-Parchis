using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Punto alrededor del cual rotará la cámara
    public float traverseSpeed;

    void Update()
    {
        // Obtener la entrada de las teclas A y D
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calcular el ángulo de rotación basado en la entrada y la velocidad
        float traverseAmount = horizontalInput * traverseSpeed * Time.deltaTime;

        // Rotar la cámara alrededor del punto objetivo
        transform.RotateAround(target.position, Vector3.up, traverseAmount);
    }
}
