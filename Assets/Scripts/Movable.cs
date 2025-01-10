using System;
using MyGrid.Code;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movable : MonoBehaviour , IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private Vector3 offset;
    [SerializeField] private LayerMask layerMask;

    private Transform currentMoveable;
    private Vector3 homePosition;
    private GridManager gridManager;
    private Mytile myTile;

    private BlockSpawnManager blockSpawnManager;
    
    private void Start()
    {
        currentMoveable = transform.parent;
        homePosition = transform.position;
        blockSpawnManager = GetComponentInParent<BlockSpawnManager>();
        gridManager = transform.parent.GetComponent<GridManager>();
        myTile = GetComponent<Mytile>();
    }

    #region  Pointers

    public void OnPointerDown(PointerEventData eventData)
    {
        // var target = Camera.main.ScreenToWorldPoint(eventData.position);
        // offset = currentMoveable.position - target;
        offset = currentMoveable.position - Camera.main.ScreenToWorldPoint(eventData.position);
        Debug.Log("OnPointerDown");
    }

    public void OnDrag(PointerEventData eventData)
    {
        // var target = Camera.main.WorldToScreenPoint(eventData.position);
        // target += offset;
        // target.z = 0;
        // currentMoveable.position = target;
        currentMoveable.position = Camera.main.ScreenToWorldPoint(eventData.position) + offset;
        Debug.Log("OnDrag");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        var allowSetToGrid = AllowSetToGrid();
        
        if (allowSetToGrid)
        {
            SetPositionAll();
            BaseGrid.Instance.CheckGrid();
            blockSpawnManager.OnPlaced();
        }
        else
        {
            BackHomeAll();
        }
    }

    #endregion

    #region Managers

    private void SetPositionAll()
        {
            foreach (var tile in gridManager.Tiles)
            {
                if (!tile.gameObject.activeSelf) continue;
                var myTile = (Mytile)tile;
                
                myTile.Movable.SetPositionToHit();
                
            }
        }

    private void BackHomeAll()
    {
        foreach (var tile in gridManager.Tiles)
        {
            if (!tile.gameObject.activeSelf) continue;
            var myTile = (Mytile)tile;
            myTile.Movable.BackHome();
        }
    }
    
    private bool AllowSetToGrid()
    {
        var allowSetToGrid = true;
        foreach (var tile in gridManager.Tiles)
        {
            if (!tile.gameObject.activeSelf) continue;

            var mytile = (Mytile)tile;
            var hit = mytile.Movable.Hit();
            if (!hit)
            {
                allowSetToGrid = false;
                break;
            }
            var baseTile = hit.transform.GetComponent<Mytile>();
            if (baseTile.OnMyTile)
            {
                allowSetToGrid = false;
                break;
            }
        }

        return allowSetToGrid;

    }
    #endregion
    

    private void SetPositionToHit()
    {
        var hit = Hit();
        var baseTile = hit.transform.GetComponent<Mytile>();
        baseTile.OnMyTile = myTile;
        var target = hit.transform.position;
        //target.z = 0.5f;
        transform.position = target;
        myTile.SetColliderActive(false);
    }
    
    private void BackHome()
    { 
        transform.position = homePosition;
    }
    
    public RaycastHit2D Hit()
    {
        var origin = transform.position;
        return Physics2D.Raycast(origin, Vector3.forward, 10f, layerMask);
    }

    // private void FixedUpdate()
    // {
    //     var hit = Hit();
    //     //Debug.Log(hit ? $"hit {hit.transform.name}": "no hit");
    //     Debug.DrawRay(transform.position, transform.transform.TransformDirection(Vector3.forward) * 10f,
    //         hit ? Color.red : Color.white);
    // }
}