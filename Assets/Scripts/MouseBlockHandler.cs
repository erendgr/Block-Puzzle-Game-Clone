using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseBlockHandler : MonoBehaviour
{
    private GameObject currentBlock;
    private Camera mainCamera;
    public LayerMask blockLayer;
    
    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)) // Sol tıklama
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 5f);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, blockLayer))
            {
                Debug.Log("raycast");
                if (hit.collider != null)
                {
                    currentBlock = hit.collider.gameObject; // Tıklanan nesne
                    Debug.Log("Tıklanan blok: " + currentBlock.name);
                }
            }
        }
    }

    void OnMouseOver()
    {
        Debug.Log("Mouse is over this object!");
    }
    
    public GameObject GetCurrentBlock()
    {
        return currentBlock;
    }
}