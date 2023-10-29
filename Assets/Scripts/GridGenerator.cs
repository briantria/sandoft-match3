using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] private Gem _gemPrefab;

    private int[,] _grid;
    private Gem[,] _gems;
    private int _gemTypeCount;

    private void Start()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        _gemTypeCount = Enum.GetNames(typeof(GemType)).Length;
        _grid = new int[GameInfo.GridSize.x, GameInfo.GridSize.y];
        _gems = new Gem[GameInfo.GridSize.x, GameInfo.GridSize.y];

        for (int row = 0; row < GameInfo.GridSize.y; row++)
        {
            for (int col = 0; col < GameInfo.GridSize.x; col++)
            {
                var gemTypeInt = UnityEngine.Random.Range(0, _gemTypeCount);
                _grid[col, row] = gemTypeInt;

                var gem = Instantiate(_gemPrefab, transform);
                gem.Setup((GemType)gemTypeInt);
                gem.transform.position = new Vector3(col*gem.Size.x, row*gem.Size.y, 0);
                _gems[col, row] = gem;
            }
        }
    }
}
