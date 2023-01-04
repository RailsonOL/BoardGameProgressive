using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    public float speed = 5.0f;
    public Transform[] allTiles;

    private bool isMoving;
    private Vector3 origPos, targetPos;
    private float timeToMoving = 0.5f;

    private int currentTileIndex;
    private Transform currentTile;

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
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && !isMoving)
        {
            StartCoroutine(MoveNext());
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && !isMoving)
        {
            StartCoroutine(MovePrevious());
        }
    }

    private IEnumerator MoveNext()
    {
        isMoving = true;
        float elapsedTime = 0;
        origPos = transform.position;
        // Obtém o próximo tile usando o índice atual do peão no array allTiles
        targetPos = allTiles[(currentTileIndex + 1) % allTiles.Length].position;
        while (elapsedTime < timeToMoving)
        {
            transform.position = Vector3.Lerp(origPos, targetPos + new Vector3(0f, 2.5f, 0f), (elapsedTime / timeToMoving));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = targetPos + new Vector3(0f, 1.0f, 0f);
        isMoving = false;
        // Atualiza o índice atual do peão e o tile atual
        currentTileIndex = (currentTileIndex + 1) % allTiles.Length;
        currentTile = allTiles[currentTileIndex];
    }

    private IEnumerator MovePrevious()
    {
        isMoving = true;
        float elapsedTime = 0;
        origPos = transform.position;
        // Obtém o tile anterior usando o índice atual do peão no array allTiles
        targetPos = allTiles[(currentTileIndex - 1 + allTiles.Length) % allTiles.Length].position;
        while (elapsedTime < timeToMoving)
        {
            transform.position = Vector3.Lerp(origPos, targetPos + new Vector3(0f, 2.5f, 0f), (elapsedTime / timeToMoving));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = targetPos + new Vector3(0f, 1.0f, 0f);
        isMoving = false;
        // Atualiza o índice atual do peão e o tile atual
        currentTileIndex = (currentTileIndex - 1 + allTiles.Length) % allTiles.Length;
        currentTile = allTiles[currentTileIndex];
    }
}

