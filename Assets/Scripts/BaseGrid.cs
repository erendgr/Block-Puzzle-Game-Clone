using System.Collections.Generic;
using MyGrid.Code;
using UnityEngine;

public class BaseGrid : Singleton<BaseGrid>
{
    [SerializeField] private GridManager gridManager;
    
    public void CheckGrid()
    {
        Debug.Log("Checking grid");
        List<int> willDestroyRowIndex = new List<int>();
        List<int> willDestroyColumnIndex = new List<int>();
        for (int i = 0; i < 10; i++)
        {
            if (IsRowFull(i))
            {
                Debug.Log($"Row Full {i}");
                willDestroyRowIndex.Add(i);
            }

            if (IsColumnFull(i))
            {
                Debug.Log($"Column Full {i}");
                willDestroyColumnIndex.Add(i);
            }
        }

        foreach (var rowIndex in willDestroyRowIndex)
        {
            for (int x = 0; x < 10; x++)
            {
                var tile = (Mytile)gridManager.GetTile(new Vector2Int(x, rowIndex));
                if(tile.OnMyTile)
                    Destroy(tile.OnMyTile.gameObject);
            }
        }

        foreach (var columnIndex in willDestroyColumnIndex)
        {
            for (int y = 0; y < 10; y++)
            {
                var tile = (Mytile)gridManager.GetTile(new Vector2Int(columnIndex, y));
                if(tile.OnMyTile)
                    Destroy(tile.OnMyTile.gameObject);
            }
        }
    }
    
    
    private bool IsRowFull(int row)
    {
        for (int i = 0; i < 10; i++)
        {
            var tile = (Mytile)gridManager.GetTile(new Vector2Int(i, row));
            if (!tile.OnMyTile)
            {
                return false;
            }
        }

        return true;
    }

    private bool IsColumnFull(int column)
    {
        for (int i = 0; i < 10; i++)
        {
            var tile = (Mytile)gridManager.GetTile(new Vector2Int(column, i));
            if (!tile.OnMyTile)
            {
                return false;
            }
        }
        return true;
    }
}