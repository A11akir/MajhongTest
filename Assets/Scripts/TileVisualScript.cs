using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class TileVisualScript : MonoBehaviour
{
    /*public GameObject clickLayer;*/

    private Transform parentTile;

    [SerializeField] private TileManager tileManager;
    
    
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

    public void TilesUnchoosed()
    {
        for (int i = 0; i < tileManager.tiles.Count; i++)
        {

            tileManager.tiles[i].transform.DOScale(1, 0.1f);
        }
    }
}



/*if (isChoosed == false)
{
    clickLayer.SetActive(true);

    parentTile = transform.parent;
    int parentCountChild = parentTile.childCount;
    transform.SetSiblingIndex(parentCountChild);
    transform.DOScale(1.1f, 0.1f);
    isChoosed = true;
}
else
{
    

    isChoosed = false;
}*/