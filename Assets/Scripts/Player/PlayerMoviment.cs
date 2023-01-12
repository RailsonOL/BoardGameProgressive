using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMoviment : MonoBehaviour
{
    public float speed = 5.0f;
    public Transform[] allTiles;

    private bool isMoving;
    private Vector3 origPos, targetPos;
    private float timeToMoving = 0.5f;

    private int currentTileIndex;
    private Transform currentTile;
    public float jumpHeight = 0.7f;

    void Start()
    {
        // Procura o tile que contém o peão como filho
        currentTile = transform.Find("Tile");
        // Verifica se o tile foi encontrado
        if (currentTile != null)
        {
            // Se sim, obtém o índice do tile no array allTiles
            currentTileIndex = System.Array.IndexOf(allTiles, currentTile);
        }
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.RightArrow))
    //     {
    //         StartCoroutine(MoveNext(3));
    //     }

    //     if (Input.GetKeyDown(KeyCode.LeftArrow))
    //     {
    //         StartCoroutine(MovePrevious());
    //     }
    // }

    public void MoveNext(int numMoves)
    {
        int movesDone = 1;
        if (!isMoving)
        {

            isMoving = true;

            targetPos = allTiles[(currentTileIndex + 1) % allTiles.Length].position;

            float distance = Vector3.Distance(transform.position, targetPos);

            int jumps = Mathf.RoundToInt(distance / 2.5f);

            DOTween.Sequence()
                .Append(transform.DOJump(targetPos + new Vector3(0f, 0.5f, 0f), jumpHeight, jumps, distance / 5).SetEase(Ease.Linear))
                .Append(transform.DOMove(targetPos + new Vector3(0f, 0.5f, 0f), timeToMoving).SetEase(Ease.Linear))
                .OnComplete(() =>
                {
                    isMoving = false;

                    currentTileIndex = (currentTileIndex + 1) % allTiles.Length;
                    currentTile = allTiles[currentTileIndex];

                    if (movesDone < numMoves)
                    {
                        movesDone++;
                        MoveNext(numMoves - 1);
                    }
                });
        }

    }


    public void MovePrevious(int numMoves)
    {
        int movesDone = 1;
        if (!isMoving)
        {

            isMoving = true;
            // Obtém o tile anterior usando o índice atual do peão no array allTiles
            targetPos = allTiles[(currentTileIndex - 1 + allTiles.Length) % allTiles.Length].position;
            //get distance between current position and target position
            float distance = Vector3.Distance(transform.position, targetPos);
            int jumps = Mathf.RoundToInt(distance / 2.5f);

            DOTween.Sequence()
                .Append(transform.DOJump(targetPos + new Vector3(0f, 0.5f, 0f), jumpHeight, jumps, distance / 5).SetEase(Ease.Linear))
                .Append(transform.DOMove(targetPos + new Vector3(0f, 0.5f, 0f), timeToMoving).SetEase(Ease.Linear))
                .OnComplete(() =>
                {
                    isMoving = false;
                    // Atualiza o índice atual do peão e o tile atual
                    currentTileIndex = (currentTileIndex - 1 + allTiles.Length) % allTiles.Length;
                    currentTile = allTiles[currentTileIndex];

                    if (movesDone < numMoves)
                    {
                        movesDone++;
                        MoveNext(numMoves - 1);
                    }
                });

        }
    }

}

