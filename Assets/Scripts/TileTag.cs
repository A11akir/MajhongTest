using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileTag : MonoBehaviour, IPointerClickHandler
{
    private TileManager tileManager;

     public Vector3Int coordinate;
    
    public void SetManager(TileManager tileManager)
    {
        this.tileManager = tileManager;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        tileManager.AddTile(gameObject);
    }
}
