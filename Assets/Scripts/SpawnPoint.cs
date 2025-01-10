using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SpawnPoint : MonoBehaviour
{
    
    public GameObject[] blockPrefabs;
    public List<GameObject> spawnedBlocks = new List<GameObject>();
    
    public void SpawnNewBlock()
    {
        int index = Random.Range(0, blockPrefabs.Length);
        GameObject newBlock = Instantiate(blockPrefabs[index], transform.position, Quaternion.identity);
        spawnedBlocks.Add(newBlock);
        
        BlockSpawnManager blockSpawnManager = newBlock.GetComponent<BlockSpawnManager>();
        if (blockSpawnManager != null)
        {
            blockSpawnManager.spawnPoint = this;
        }
        
        Debug.Log($"Yeni blok spawn edildi: {newBlock.name}");
    }

    private void Update()
    {
        if (spawnedBlocks.Count == 0 || spawnedBlocks[spawnedBlocks.Count - 1] == null)
        {
            SpawnNewBlock();
        }
    }
}