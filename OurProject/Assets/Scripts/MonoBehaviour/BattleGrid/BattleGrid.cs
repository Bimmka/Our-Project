using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BattleGrid : MonoBehaviour
{
    [SerializeField] private Transform cellParentTransform;

    private Grid parentGrid;

    private Tilemap tilemap;

    private BoundsInt bounds;

    private TileBase[] allTiles;

    private Cell[] cellGrid;

    public static Action<Cell[], int,int> AllCellsCreated;             


    private void Awake()
    {
        parentGrid = GetComponentInParent<Grid>();
        tilemap = GetComponent<Tilemap>();
        tilemap.CompressBounds();

        GameObject cell = Resources.Load("ramka", typeof(GameObject)) as GameObject;
        int count = 0;
        bounds = tilemap.cellBounds;
        allTiles = tilemap.GetTilesBlock(bounds);
        cellGrid = new Cell[bounds.size.x * bounds.size.y];
        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                count++;
                if (tile != null)
                {
                    GameObject currentCell = Instantiate(cell, tilemap.CellToWorld(new Vector3Int(x + bounds.xMin, y + bounds.yMin, 0)) + new Vector3(tilemap.tileAnchor.x, tilemap.tileAnchor.y, 0), Quaternion.identity, cellParentTransform);
                    cellGrid[x + y * bounds.size.x] = currentCell.GetComponent<Cell>();
                }
                else cellGrid[x + y * bounds.size.x] = null;
            }
        }
    }
    void Start()
    {
        
       if (AllCellsCreated != null) AllCellsCreated(cellGrid, bounds.size.x, bounds.size.y);
    }
}
