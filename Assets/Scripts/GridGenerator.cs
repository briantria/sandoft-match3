using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    private int[,] _grid;
    private int _gemTypeCount;

    private void Start()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        _gemTypeCount = Enum.GetNames(typeof(GemType)).Length;
        _grid = new int[GameInfo.GridSize.x, GameInfo.GridSize.y];

        for (int row = 0; row < GameInfo.GridSize.y; row++)
        {
            for (int col = 0; col < GameInfo.GridSize.x; col++)
            {
                _grid[col, row] = UnityEngine.Random.Range(0, _gemTypeCount);
            }
        }
    }
}
