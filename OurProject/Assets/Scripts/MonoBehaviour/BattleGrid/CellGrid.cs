using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CellGrid : MonoBehaviour
{
    private Cell[] cells;                               //массив клеток

    private Cell[,] cellsMatrix;                        //массив клеток переведнный в двумерный массив

    private int rowCountInMatrix;                       //количество столбцов в матрице клеток
    private int stringCountInMatrix;                    //количество строк в матрице клеток

    private void Awake()
    {
        BattleGrid.AllCellsCreated += GetAllCells;
    }

    private void OnDestroy()
    {
        BattleGrid.AllCellsCreated -= GetAllCells;

    }

    #region Создание массива клеток и матрицы клеток

    /// <summary>
    /// Метод, вызываемый при спавне всех клеток поверх грида
    /// </summary>
    /// <param name="rowCount">Количество столбцов</param>
    /// <param name="stringCount">Количество строк</param>
    private void GetAllCells(Cell[] cellGrid, int rowCount, int stringCount)
    {
        cells = cellGrid;        

        CreateCellsMatrix(rowCount, stringCount);
    }

    /// <summary>
    /// Метод для задания матрицы клеток
    /// </summary>
    /// <param name="rowCount">Количество столбцов</param>
    /// <param name="stringCount">Количество строк</param>
    private void CreateCellsMatrix(int rowCount, int stringCount)
    {
        rowCountInMatrix = rowCount;
        stringCountInMatrix = stringCount;

        cellsMatrix = new Cell[stringCountInMatrix, rowCountInMatrix];

        for (int rowIndex = 0; rowIndex < rowCountInMatrix; rowIndex++)
        {
            for (int stringIndex = 0; stringIndex < stringCountInMatrix; stringIndex++)
            {
                cellsMatrix[stringIndex, rowIndex] = cells[stringIndex + rowIndex * stringCountInMatrix];
            }
        }

    }

    #endregion


}
