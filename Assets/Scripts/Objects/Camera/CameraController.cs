using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  public Transform target;
  public float speed = 5.0f;

  void Update()
  {
    // Obtém a posição atual da câmera
    Vector3 currentPosition = transform.position;
    // Obtém a posição atual do player
    Vector3 targetPosition = target.position;
    // Calcula a diferença entre as posições
    Vector3 difference = new Vector3(targetPosition.x - currentPosition.x, 0, targetPosition.z - currentPosition.z);
    // Move a câmera em direção ao player com a velocidade especificada
    transform.Translate(difference * speed * Time.deltaTime, Space.World);
    // Olha para o player
    transform.LookAt(target);
  }
}