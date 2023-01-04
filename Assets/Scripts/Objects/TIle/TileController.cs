using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public GameObject[] tileList;
    public GameObject StartingTile;
    public GameObject EndingTile;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HasSpaceToMove()
    {

    }

    public GameObject GetNextTile(GameObject currentTile)
    {
        //get the current tile's index
        int currentIndex = System.Array.IndexOf(tileList, currentTile);

        //get the next tile's index
        int nextIndex = currentIndex + 1;

        //check if the next tile is the last tile
        if (nextIndex == tileList.Length)
        {
            //if it is the last tile, return the ending tile
            return EndingTile;
        }
        else
        {
            //if it is not the last tile, return the next tile
            return tileList[nextIndex];
        }
    }
}
