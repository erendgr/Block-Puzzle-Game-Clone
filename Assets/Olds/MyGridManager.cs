// using UnityEngine;
//
// public class GridManager : MonoBehaviour
// {
//     [SerializeField] private GameObject gridPrefab;
//     [SerializeField] private int rows = 10;
//     [SerializeField] private int columns = 10;
//     [SerializeField] public float cellSize = 1f;
//     private bool[,] grid;
//     
//    
//     
//     [ContextMenu(nameof(GenerateGrid))]
//     public void GenerateGrid()
//     {
//         ClearGrid();
//         
//         for (int x = 0; x < columns; x++)
//         {
//             for (int y = 0; y < rows; y++)
//             {
//                 Vector2 pos = new Vector2(y * cellSize, x * cellSize);
//                 if (gridPrefab != null)
//                 {
//                     GameObject cell = Instantiate(gridPrefab, pos, Quaternion.identity);
//                     cell.name = $"Cell ({x}, {y})";
//                 }
//                 else
//                 {
//                     Debug.Log("Grid Prefab is null");
//                 }
//             }
//         }    
//         
//         
//         
//     }
//     private void ClearGrid()
//     {
//         for (int i = transform.childCount - 1; i >= 0; i++)
//         {
//             DestroyImmediate(transform.GetChild(i).gameObject);
//         }
//     }
//     
//     [SerializeField] private LayerMask gridLayer; // Grid layer'ını kullanacağız
//     private bool[,] gridOccupied;
//     public int gridWidth = 5;
//     public int gridHeight = 5;
//
//     private void Start()
//     {
//         gridOccupied = new bool[gridWidth, gridHeight]; // Gridin durumunu başlat
//     }
//
//     public bool IsCellEmpty(Vector2Int gridPosition)
//     {
//         // Grid hücresinin boş olup olmadığını kontrol eder
//         if (gridPosition.x >= 0 && gridPosition.x < gridWidth &&
//             gridPosition.y >= 0 && gridPosition.y < gridHeight)
//         {
//             return !gridOccupied[gridPosition.x, gridPosition.y];
//         }
//         return false;
//     }
//
//     public void SetCellOccupied(Vector2Int gridPosition, bool isOccupied)
//     {
//         // Grid hücresini dolu ya da boş olarak işaretler
//         if (gridPosition.x >= 0 && gridPosition.x < gridWidth &&
//             gridPosition.y >= 0 && gridPosition.y < gridHeight)
//         {
//             gridOccupied[gridPosition.x, gridPosition.y] = isOccupied;
//         }
//     }
//
//     public Vector2 GetWorldPosition(Vector2Int gridPosition)
//     {
//         // Grid hücresinin dünya pozisyonunu döndürür
//         return new Vector2(gridPosition.x * cellSize + (cellSize / 2), gridPosition.y * cellSize + (cellSize / 2));
//     }
// }
