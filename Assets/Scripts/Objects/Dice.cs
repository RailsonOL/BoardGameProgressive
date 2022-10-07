using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    static Rigidbody rb;
    public static Vector3 diceVelocity;

    Vector3 dicePosition;
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
            float x = Random.Range(0, 1500);
            float y = Random.Range(0, 1500);
            float z = Random.Range(0, 1500);

            transform.position = dicePosition;
            transform.rotation = Quaternion.identity;

            rb.AddForce(transform.up * 500);
            rb.AddTorque(x, y, z);
        }
    }
}
