using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileLogicScript : MonoBehaviour
{
    [SerializeField] private TileManager tileManager;
    [SerializeField] private TileVisualScript tileVisualScript;
    [SerializeField] private AvailableLogicTailes availableLogicTailes;
    [SerializeField] private CoordinateTailes coordinateTailes;
    


    private void OnEnable()
    {
        tileManager.OnTilesListChanged += ChooseTile;
    }

    private void OnDisable()
    {
        tileManager.OnTilesListChanged -= ChooseTile;
    }

    private void ChooseTile()
    {
        if (tileManager.tiles.Count == 2)
        {
            CheckEqualTiles();
        }
    }

    private void CheckEqualTiles()
    {
        if (tileManager.tiles[0].name == tileManager.tiles[1].name &&
            tileManager.tiles[0] != tileManager.tiles[1] &&
            availableLogicTailes.CheckObstruction(tileManager.tiles[0]) == true && 
            availableLogicTailes.CheckObstruction(tileManager.tiles[1]) == true)
        {


            var tempTile1 = tileManager.tiles[0].GetComponent<TileTag>();
            var coord1 = tempTile1.coordinate;
            
            var tempTile2 = tileManager.tiles[1].GetComponent<TileTag>();
            var coord2 = tempTile2.coordinate;
            
            
            coordinateTailes.coordinates.Remove(coord1);
            coordinateTailes.coordinates.Remove(coord2);
            coord1 = new Vector3Int(999, 999, 999);
            coord2 = new Vector3Int(999, 999, 999);
            
            tileManager.tiles[0].SetActive(false);
            tileManager.tiles[1].SetActive(false);
            
            Debug.Log("Удалена плитка: " + coord1);
            Debug.Log("Удалена плитка: " + coord2);
            Debug.Log("Оставшиеся координаты: " + string.Join(", ", coordinateTailes.coordinates));
            
        }
        else
        {
            tileVisualScript.TilesUnchoosed();
        }

        tileManager.tiles.Clear();
    }
}