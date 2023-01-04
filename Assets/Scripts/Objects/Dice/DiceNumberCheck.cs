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
                    Dice.DiceNumber = 1;
                    break;
                case "2":
                    Dice.DiceNumber = 2;
                    break;
                case "3":
                    Dice.DiceNumber = 3;
                    break;
                case "4":
                    Dice.DiceNumber = 4;
                    break;
                case "5":
                    Dice.DiceNumber = 5;
                    break;
                case "6":
                    Dice.DiceNumber = 6;
                    break;
            }
        }
    }

}