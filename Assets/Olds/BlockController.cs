// using UnityEngine;
// using UnityEngine.EventSystems;
//
// public class BlockController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
// {
//     [SerializeField] private LayerMask gridLayer; // Grid hücrelerine çarpacak şekilde maskeyi ayarla
//     private GridManager gridManager;
//     private Vector3 offset;
//     private Transform[] blockPieces; // Alt nesneleri tutacak bir array
//
//     private void Start()
//     {
//         // Blok prefabındaki tüm alt nesneleri al
//         blockPieces = GetComponentsInChildren<Transform>(); // Bu, sadece alt objeleri alır (kendisi hariç)
//     }
//
//     public void OnPointerDown(PointerEventData eventData)
//     {
//         // İlk tıklama sırasında offset'i alıyoruz
//         offset = transform.position - Camera.main.ScreenToWorldPoint(eventData.position);
//     }
//
//     public void OnDrag(PointerEventData eventData)
//     {
//         // Sürüklerken blokları hareket ettiriyoruz
//         transform.position = Camera.main.ScreenToWorldPoint(eventData.position) + offset;
//     }
//
//     public void OnPointerUp(PointerEventData eventData)
//     {
//         // Raycast ile en uygun grid pozisyonunu buluyoruz
//         Vector2Int gridPosition = GetGridPositionFromRaycast();
//
//         if (gridPosition != Vector2Int.zero) // Eğer bir hücreye çarptıysa
//         {
//             // Blok doğru grid pozisyonuna yerleşiyor
//             transform.position = gridManager.GetWorldPosition(gridPosition);
//             gridManager.SetCellOccupied(gridPosition, true); // Hücreyi dolu olarak işaretle
//         }
//         else
//         {
//             // Eğer çarpmadıysa, eski pozisyona geri dön
//             transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
//         }
//     }
//
//     private Vector2Int GetGridPositionFromRaycast()
//     {
//         foreach (var piece in blockPieces) // Her bir alt objeyi kontrol et
//         {
//             Vector2 piecePosition = piece.position;
//             RaycastHit2D hit = Physics2D.Raycast(piecePosition, Vector2.zero, Mathf.Infinity, gridLayer);
//
//             if (hit.collider != null)
//             {
//                 Debug.Log("Raycast hit: " + hit.collider.gameObject.name);  // Çarpan objenin ismini debugla
//
//                 // Çarpılan hücrenin grid pozisyonunu al
//                 Vector2Int gridPosition = new Vector2Int(Mathf.FloorToInt(hit.point.x / gridManager.cellSize),
//                                                           Mathf.FloorToInt(hit.point.y / gridManager.cellSize));
//                 return gridPosition;
//             }
//         }
//         return Vector2Int.zero; // Eğer hiçbir hücreye çarpmadıysa
//     }
// }