using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileStates : MonoBehaviour
{
    // SerializeFields to set for each tile on field
    // value determines movement for player & enemy units on edge tiles
    [SerializeField] private bool isTop;
    [SerializeField] private bool isBot;
    [SerializeField] private bool isLeft;
    [SerializeField] private bool isRight;
    [SerializeField] private int tileNum;


    // get functions to return if the tile is an edge tile
    public bool IsTop
    {
        get { return isTop; }
    }

    public bool IsBot
    {
        get { return isBot; }
    }

    public bool IsLeft
    {
        get { return isLeft; }
    }

    public bool IsRight
    {
        get { return isRight; }
    }

    public int TileNum
    {
        get { return tileNum; }
    }
}
