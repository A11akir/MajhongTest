using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class TileVisualScript : MonoBehaviour
{
    private Transform parentTile;

    [SerializeField] private TileManager tileManager;
    [SerializeField] private LevelGeneration levelGeneration;
    [SerializeField] private AvailableLogicTailes availableLogicTailes;
    
    private void OnEnable()
    {
        tileManager.OnTilesListChanged += TilesVisualCheck;
    }
    
    

    private void OnDisable()
    {
        tileManager.OnTilesListChanged -= TilesVisualCheck;
    }
    
    private void TilesVisualCheck()
    {
        for (int i = 0; i < tileManager.tiles.Count; i++)
        {
            
            tileManager.tiles[i].transform.DOScale(1.1f, 0.1f);
            
            parentTile = tileManager.tiles[i].transform.parent;
            int parentCountChild = parentTile.childCount;
            tileManager.tiles[i].transform.SetSiblingIndex(parentCountChild);
        }
    }

    public void TilesAvailableVisual()
    {
        for (int i = 0; i < levelGeneration.tilesGO.Count; i++)
        {
            var tile = levelGeneration.tilesGO[i].GetComponent<TileTag>();
            
            if (availableLogicTailes.CheckObstruction(levelGeneration.tilesGO[i]))
            {
                
                tile.SetUnblocked();
            }
            else
            {
                tile.SetBlocked();
            }
        }
    }

    public void TilesUnchoosed()
    {
        for (int i = 0; i < tileManager.tiles.Count; i++)
        {
            tileManager.tiles[i].transform.DOScale(1, 0.1f);
        }
    }
}