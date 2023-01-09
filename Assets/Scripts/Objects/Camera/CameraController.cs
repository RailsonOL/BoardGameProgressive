using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // jogador para seguir
    public float smoothing = 5f; // suavização da câmera

    Vector3 offset; // distância entre a câmera e o jogador

    void Start()
    {
        // Calcula o offset inicial entre a câmera e o jogador
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        // Calcula a posição desejada da câmera
        Vector3 targetCamPos = target.position + offset;

        // Suaviza a transição da câmera para a posição desejada
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}