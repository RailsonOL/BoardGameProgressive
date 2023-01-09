using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    private Rigidbody rb;
    public int diceNumberResult;

    private Vector3 dicePosition;

    public bool isRolling;

    void Start()
    {
        dicePosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Se o usuário apertar a tecla espaço...
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Rola o dado
            RollDice();
            //Debug.Log("O dado foi lançado...");
        }

        if (isRolling)
        {
            Debug.Log("O dado está rolando...");
        }

        // Se o dado estiver rolando e parar de se mover...
        if (isRolling && rb.velocity.magnitude < 0.1)
        {
            // Checa novamente se parou mesmo
            StartCoroutine(WaitAndCalculateResult());
        }
    }

    IEnumerator WaitAndCalculateResult()
    {
        // Pausa a execução do script por 0.6 segundos
        yield return new WaitForSeconds(0.4f);

        if (rb.velocity.magnitude < 0.1)
        {
            isRolling = false;
        }
        else
        {
            isRolling = true;
        }
    }

    public void StopDice()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public void RollDice()
    {
        float x = Random.Range(0, 1500);
        float y = Random.Range(0, 1500);
        float z = Random.Range(0, 1500);

        transform.position = dicePosition;
        transform.rotation = Quaternion.identity;

        rb.AddForce(transform.up * 500);
        rb.AddTorque(x, y, z);
        isRolling = true;
    }
}
