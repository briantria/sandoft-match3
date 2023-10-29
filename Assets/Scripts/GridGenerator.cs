using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Conditions:
 *  [ ] no more than 2 same gems (vertical & horizontal)
 *  [ ] grid should be solvable
 *  [x] dynamic level
 *  [x] random each run
 *  [?] run on android
 *  
 * Bonus:
 *  [x] visual representation
 *  [ ] animations
 *  [ ] refresh button
 *  [x] git repo + LFS
 */

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
                //var gemTypeInt = GetValidGemTypeInt(col, row);
                _grid[col, row] = gemTypeInt;

                var gem = Instantiate(_gemPrefab, transform);
                gem.Setup((GemType)gemTypeInt);
                gem.transform.position = new Vector3(col*gem.Size.x, row*gem.Size.y, 0);
                _gems[col, row] = gem;
            }
        }
    }

    // note: I ran out of time
    //  my idea is to generate another random gem type
    //  if the next 2 gemtypes beside the current gem are already equal
    private int GetValidGemTypeInt(int col, int row)
    {
        var gemTypeInt = UnityEngine.Random.Range(0, _gemTypeCount);

        if (col < 2 && row < 2)
            return gemTypeInt;

        if (col >= GameInfo.GridSize.x - 2 && row >= GameInfo.GridSize.y - 2)
            return gemTypeInt;

        if (col < 2 || col >= GameInfo.GridSize.x - 2)
            return GetValidGemTypeForCol(col, row, gemTypeInt);

        if (row < 2 || row >= GameInfo.GridSize.y - 2)
            return GetValidGemTypeForRow(col, row, gemTypeInt);

        // todo: check both directions

        return gemTypeInt;
    }

    private int GetValidGemTypeForRow(int col, int row, int gemTypeInt = 0)
    {
        if (_grid[col - 1, row] != _grid[col - 2, row] &&
            _grid[col + 1, row] != _grid[col + 2, row])
        {
            return gemTypeInt;
        }

        while (gemTypeInt == _grid[col - 1, row] ||
               gemTypeInt == _grid[col + 1, row])
        {
            gemTypeInt = UnityEngine.Random.Range(0, _gemTypeCount);
        }

        return gemTypeInt;
    }

    private int GetValidGemTypeForCol(int col, int row, int gemTypeInt = 0)
    {
        if (_grid[col, row - 1] != _grid[col, row - 2] &&
            _grid[col, row + 1] != _grid[col, row + 2])
        {
            return gemTypeInt;
        }

        while (gemTypeInt == _grid[col, row - 1] ||
               gemTypeInt == _grid[col, row + 1])
        {
            gemTypeInt = UnityEngine.Random.Range(0, _gemTypeCount);
        }

        return gemTypeInt;
    }
}
