using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    static Rigidbody rb;
    public static Vector3 diceVelocity;

    Vector3 dicePosition;

    public static bool isRolling { get; set; }
    public static int DiceNumber { get; set; }

    void Start()
    {
        dicePosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        diceVelocity = rb.velocity;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RollDice();
        }
    }

    public static void StopDice()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public void RollDice(){
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
