using System;
using MyGrid.Code;
using UnityEngine;

public class Mytile : TileController
{
    public Movable Movable { get; private set; }
    public Mytile OnMyTile; //{ get; private set; }

    private Collider2D collider;
    
    private void Start()
    {
        Movable = GetComponent<Movable>();
        collider = GetComponent<Collider2D>();
    }

    public void SetColliderActive(bool active)
    {
        collider.enabled = active;
    }
}