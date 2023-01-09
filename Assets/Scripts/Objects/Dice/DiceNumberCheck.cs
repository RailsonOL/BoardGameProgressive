using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceNumberCheck : MonoBehaviour
{
    public Dice dice;
    public PlayerMoviment playerMoviment;

    private void OnTriggerStay(Collider col)
    {
        if (!dice.isRolling)
        {
            StartCoroutine(WaitAndSetResult(0.4f, col));
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartCoroutine(playerMoviment.MoveNext(dice.diceNumberResult));
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StartCoroutine(playerMoviment.MovePrevious());
        }
    }

    IEnumerator WaitAndSetResult(float seconds, Collider col)
    {
        // Pausa a execução do script por 0.6 segundos
        yield return new WaitForSeconds(seconds);

        switch (col.gameObject.name)
        {
            case "1":
                dice.diceNumberResult = 6;
                break;
            case "2":
                dice.diceNumberResult = 4;
                break;
            case "3":
                dice.diceNumberResult = 5;
                break;
            case "4":
                dice.diceNumberResult = 2;
                break;
            case "5":
                dice.diceNumberResult = 3;
                break;
            case "6":
                dice.diceNumberResult = 1;
                break;
        }

        Debug.Log("O dado parou de verdade. Resultado: " + dice.diceNumberResult);
    }

}