using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TileTag : MonoBehaviour, IPointerClickHandler
{
    private TileManager tileManager;
    
    [SerializeField] private Image image;
    
    Color32 originalColor = new Color32(255, 250, 250, 160);
    Color32 blocklColor = new Color32(255, 250, 250, 90);
    
     public Vector3 coordinate;
    
    public void SetManager(TileManager tileManager)
    {
        this.tileManager = tileManager;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        tileManager.AddTile(gameObject);
    }

    public void SetBlocked()
    {
        image.color = blocklColor;
    }

    public void SetUnblocked()
    {
        image.color = originalColor;
    }
    
}
