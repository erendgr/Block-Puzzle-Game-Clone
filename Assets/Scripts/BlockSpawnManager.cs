using System;
using UnityEngine;

public class BlockSpawnManager : MonoBehaviour
{
    public SpawnPoint spawnPoint;
    
    public void OnPlaced()
    {
        spawnPoint.spawnedBlocks.Remove(gameObject);
    }
    
    void Update()
    {
        bool allInactive = true;

        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                allInactive = false;
                break;
            }
        }
        
        if (allInactive)
        {
            Destroy(gameObject);
        }
    }
}