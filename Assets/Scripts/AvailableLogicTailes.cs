using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableLogicTailes : MonoBehaviour
{
    [SerializeField] TileManager tileManager;
    [SerializeField] CoordinateTailes coordinateTailes;

    public bool CheckObstruction(GameObject tile)
    {
        TileTag tileTag = tile.GetComponent<TileTag>();
        Vector3Int currentCoord = tileTag.coordinate;

        List<Vector3Int> allCoordinates = coordinateTailes.coordinates;
        
        Debug.Log("Оставшиеся координаты: " + string.Join(", ", coordinateTailes.coordinates));
        bool hasLeft = false;
        bool hasRight = false;

        foreach (Vector3Int other in allCoordinates)
        {
            if ( other.z == currentCoord.z)
            {
                if (currentCoord.x == other.x - 1)
                    hasLeft = true;

                if (currentCoord.x == other.x + 1)
                    hasRight = true;
            }

            if (hasLeft && hasRight)
                return false;
        }

        return true;
    }
}