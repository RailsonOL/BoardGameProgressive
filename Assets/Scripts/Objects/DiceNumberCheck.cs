using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceNumberCheck : MonoBehaviour
{
    public GameObject dice;

    private void OnTriggerStay(Collider col) {
        if(dice.GetComponent<Rigidbody>().velocity.magnitude <= 0.01f) {
            switch (col.gameObject.name)
            {
                case "1":
                    Debug.Log("6");
                    break;
                case "2":
                    Debug.Log("5");
                    break;
                case "3":
                    Debug.Log("4");
                    break;
                case "4":
                    Debug.Log("3");
                    break;
                case "5":
                    Debug.Log("2");
                    break;
                case "6":
                    Debug.Log("1");
                    break;
            }
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
