using System;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public List<GameObject> tiles;
    
    public event Action OnTilesListChanged; 
    
    public void AddTile(GameObject tile)
    {
        tiles.Add(tile);
        OnTilesListChanged?.Invoke();
    }

    public void RemoveTile(GameObject tile)
    {
        tiles.Remove(tile);
        OnTilesListChanged?.Invoke();
    }
} 